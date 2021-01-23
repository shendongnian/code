            //Define a single StringConverter and LongConverter to re-use
            cwbx.StringConverter stringConverter = new cwbx.StringConverter();
            cwbx.LongConverter longConverter = new cwbx.LongConverter();
            //Type the user space name only once.  It's re-used a lot.
            String userSpaceName = "HRAHMAN   QGPL      ";
            //Connect to the AS/400
            AS400System as400 = new AS400System();
            as400.Define("MY_SYSTEM_HOST_ADDRESS");
            as400.UserID = "MY_USER";
            as400.Password = "MY_PASSWORD";
            as400.Connect(cwbcoServiceEnum.cwbcoServiceRemoteCmd);
            //Define the error structure once, to be re-used a lot.
            Structure sc2 = new Structure();
            sc2.Fields.Append("bytesprov", 4);
            sc2.Fields.Append("bytesavail", 4);
            sc2.Fields.Append("messageid", 7);
            sc2.Fields.Append("err", 1);
            sc2.Fields.Append("messagedta", 100);
            sc2.Fields["bytesavail"].Value = longConverter.ToBytes(sc2.Length);
            //Create the user space
            cwbx.Program quscrtus = new cwbx.Program();
            quscrtus.system = as400;
            quscrtus.LibraryName = "QSYS";
            quscrtus.ProgramName = "QUSCRTUS";
            cwbx.ProgramParameters quscrtusParms = new cwbx.ProgramParameters();
            quscrtusParms.Append("UserSpaceName", cwbrcParameterTypeEnum.cwbrcInput, 20).Value = stringConverter.ToBytes(userSpaceName);
            quscrtusParms.Append("ExtendedAttr", cwbrcParameterTypeEnum.cwbrcInput, 10).Value = stringConverter.ToBytes("".PadRight(10));
            quscrtusParms.Append("InitialSize", cwbrcParameterTypeEnum.cwbrcInput, 4).Value = longConverter.ToBytes(1);
            quscrtusParms.Append("InitialValue", cwbrcParameterTypeEnum.cwbrcInput, 1).Value = longConverter.ToBytes(0);
            quscrtusParms.Append("Auth", cwbrcParameterTypeEnum.cwbrcInput, 10).Value = stringConverter.ToBytes("*ALL".PadRight(10));
            quscrtusParms.Append("Desc", cwbrcParameterTypeEnum.cwbrcInput, 50).Value = stringConverter.ToBytes("QUSLSPL Results".PadRight(50));
            quscrtusParms.Append("Replace", cwbrcParameterTypeEnum.cwbrcInput, 10).Value = stringConverter.ToBytes("*YES".PadRight(10));
            quscrtusParms.Append("APIError", cwbrcParameterTypeEnum.cwbrcInout, sc2.Length).Value = sc2.Bytes;
            quscrtus.Call(quscrtusParms);
            sc2.Bytes = quscrtusParms["APIError"].Value;
            if (((string)stringConverter.FromBytes(sc2.Fields["messageid"].Value)).Trim().Length > 0)
            {
                //deal with error
                return;
            }
            //Call the list spooled files API
            cwbx.Program quslspl = new cwbx.Program();
            quslspl.system = as400;
            quslspl.LibraryName = "QSYS";
            quslspl.ProgramName = "QUSLSPL";
            ProgramParameters quslsplParms = new cwbx.ProgramParameters();
            quslsplParms.Append("usrspcnam", cwbrcParameterTypeEnum.cwbrcInput, 20).Value = stringConverter.ToBytes(userSpaceName); //user space name
            quslsplParms.Append("frmname", cwbrcParameterTypeEnum.cwbrcInput, 8).Value = stringConverter.ToBytes("SPLF0200"); //Format
            quslsplParms.Append("usrnam", cwbrcParameterTypeEnum.cwbrcInput, 10).Value = stringConverter.ToBytes("*CURRENT".PadRight(10)); //User Name
            quslsplParms.Append("cola", cwbrcParameterTypeEnum.cwbrcInput, 20).Value = stringConverter.ToBytes("*ALL".PadRight(20)); //qualified output queue
            quslsplParms.Append("frmtyp", cwbrcParameterTypeEnum.cwbrcInput, 10).Value = stringConverter.ToBytes("*ALL".PadRight(10)); //form type
            quslsplParms.Append("usrdta", cwbrcParameterTypeEnum.cwbrcInput, 10).Value = stringConverter.ToBytes("*ALL".PadRight(10)); //user-specific data
            quslsplParms.Append("error", cwbrcParameterTypeEnum.cwbrcInout, sc2.Length).Value = sc2.Bytes; //error
            quslsplParms.Append("qualifiedjobnm", cwbrcParameterTypeEnum.cwbrcInput, 26).Value = stringConverter.ToBytes("".PadRight(26)); //qualified job name
            //keys. The SPLF0200 structure uses a list of field keys.  So we tell the API which keys we want and that's what it returns.
            cwbx.Structure keys = new cwbx.Structure();
            keys.Fields.Append("Spooledfilename", 4).Value = longConverter.ToBytes(201);
            keys.Fields.Append("Username", 4).Value = longConverter.ToBytes(203);
            keys.Fields.Append("opqueue", 4).Value = longConverter.ToBytes(206);
            keys.Fields.Append("userdata", 4).Value = longConverter.ToBytes(209);
            keys.Fields.Append("status", 4).Value = longConverter.ToBytes(210);
            keys.Fields.Append("totpages", 4).Value = longConverter.ToBytes(211);
            keys.Fields.Append("copies", 4).Value = longConverter.ToBytes(213);
            keys.Fields.Append("openeddate", 4).Value = longConverter.ToBytes(216);
            keys.Fields.Append("opentime", 4).Value = longConverter.ToBytes(217);
            keys.Fields.Append("jobid", 4).Value = longConverter.ToBytes(218);
            keys.Fields.Append("fileid", 4).Value = longConverter.ToBytes(219);
            quslsplParms.Append("keys", cwbrcParameterTypeEnum.cwbrcInput, keys.Length).Value=keys.Bytes;
            quslsplParms.Append("numberoffields", cwbrcParameterTypeEnum.cwbrcInput, 4).Value = longConverter.ToBytes(keys.Fields.Count); //number of keys to return
            quslspl.Call(quslsplParms);
            sc2.Bytes = quslsplParms["error"].Value;
            if (((string)stringConverter.FromBytes(sc2.Fields["messageid"].Value)).Trim().Length > 0)
            {
                //deal with error
                return;
            }
            //Get the list information from the user space
            cwbx.Structure listInfo = new cwbx.Structure();
            listInfo.Fields.Append("OffsetToData", 4);
            listInfo.Fields.Append("DataSectionSize", 4);
            listInfo.Fields.Append("NumberOfEntries", 4);
            listInfo.Fields.Append("EntrySize", 4);
            //The List information data structure starts at zero-based position 0x7c.  The retrieve user space
            //API uses 1-based indexing.  Retreive the list information from the user space.
            cwbx.Program qusrtvus = new cwbx.Program();
            qusrtvus.system = as400;
            qusrtvus.LibraryName = "QSYS";
            qusrtvus.ProgramName = "QUSRTVUS";
            cwbx.ProgramParameters qusrtvusParms = new cwbx.ProgramParameters();
            qusrtvusParms.Append("UserSpaceName", cwbrcParameterTypeEnum.cwbrcInput, 20).Value = stringConverter.ToBytes(userSpaceName);
            qusrtvusParms.Append("StartingPosition", cwbrcParameterTypeEnum.cwbrcInput, 4).Value = longConverter.ToBytes(0x7c + 1);
            qusrtvusParms.Append("Length", cwbrcParameterTypeEnum.cwbrcInput, 4).Value = longConverter.ToBytes(listInfo.Length);
            qusrtvusParms.Append("Receiver", cwbrcParameterTypeEnum.cwbrcInout, listInfo.Length);
            qusrtvusParms.Append("APIError", cwbrcParameterTypeEnum.cwbrcInout, sc2.Length).Value = sc2.Bytes;
            qusrtvus.Call(qusrtvusParms);
            sc2.Bytes = qusrtvusParms["APIError"].Value;
            if (((string)stringConverter.FromBytes(sc2.Fields["messageid"].Value)).Trim().Length > 0)
            {
                //deal with error
                return;
            }
            listInfo.Bytes = qusrtvusParms["Receiver"].Value;
            int offsetToData = longConverter.FromBytes(listInfo.Fields["OffsetToData"].Value);
            int numberOfEntries = longConverter.FromBytes(listInfo.Fields["NumberOfEntries"].Value);
            int entrySize = longConverter.FromBytes(listInfo.Fields["EntrySize"].Value);
            //Define the structure to receive the SPLF0200 Field data.  This is described in the QUSLSPL API.
            //Note: According to the API documentation, this is the only part that repeats for each key.  The first
            //four bytes of the SPLF0200 structure is the count of keys returned.
            cwbx.Structure SPLF0200Field = new cwbx.Structure(); //individual field value data
            SPLF0200Field.Fields.Append("LengthOfInformation", 4);
            SPLF0200Field.Fields.Append("KeyField", 4);
            SPLF0200Field.Fields.Append("TypeOfData", 1);
            SPLF0200Field.Fields.Append("Reserved", 3);
            SPLF0200Field.Fields.Append("LengthOfData", 4);
                        
            //Loop through each entry in the list and get the field values by key
            for (int currentEntry = 0; currentEntry < numberOfEntries; currentEntry++)
            {
                qusrtvusParms["StartingPosition"].Value = longConverter.ToBytes(offsetToData + (currentEntry * entrySize) + 1);
                qusrtvusParms["Length"].Value = longConverter.ToBytes(entrySize);
                qusrtvusParms["Receiver"].Length = entrySize;
                qusrtvus.Call(qusrtvusParms);
                sc2.Bytes = qusrtvusParms["APIError"].Value;
                if (((string)stringConverter.FromBytes(sc2.Fields["messageid"].Value)).Trim().Length > 0)
                {
                    //deal with error
                    return;
                }
                //According to the SPLF0200 format, the first 4-byte integer is the number of fields returned.
                //After that, it's a variable list of key structures.
                byte[] entry = qusrtvusParms["Receiver"].Value;
                byte[] numberOfFieldsReturnedBytes = new byte[4];
                Array.Copy(entry, 0, numberOfFieldsReturnedBytes, 0, 4);
                int numberOfFieldsReturned = longConverter.FromBytes(numberOfFieldsReturnedBytes);
                int lastBufferEnd = 4;
                //Fields to hold the spooled file field elements.  Note: In a production environment, I would normally
                //create a class to hold all of this, but this is just for sample purposes.
                String spooledFileName = "";
                String userName = "";
                String opqueue = "";
                String userdata = "";
                String status = "";
                int totpages = 0;
                int copies = 0;
                String openeddate = "";
                String opentime = "";
                byte[] jobid = new byte[16];
                byte[] fileid = new byte[16];
                for (int currentField = 0; currentField < numberOfFieldsReturned; currentField++)
                {
                    byte[] SPLF0200FieldBytes = new byte[SPLF0200Field.Length];
                    Array.Copy(entry, lastBufferEnd, SPLF0200FieldBytes, 0, SPLF0200FieldBytes.Length);
                    SPLF0200Field.Bytes = SPLF0200FieldBytes;
                    int fieldDataLength = longConverter.FromBytes(SPLF0200Field.Fields["LengthOfData"].Value);
                    int fieldInfoLength = longConverter.FromBytes(SPLF0200Field.Fields["LengthOfInformation"].Value);
                    int fieldKey = longConverter.FromBytes(SPLF0200Field.Fields["KeyField"].Value);
                    byte[] fieldDataBytes = new byte[fieldDataLength];
                    Array.Copy(entry, lastBufferEnd + 16, fieldDataBytes, 0, fieldDataLength);
                    lastBufferEnd = lastBufferEnd + fieldInfoLength;
                    switch (fieldKey) {
                        case 201:
                            spooledFileName = stringConverter.FromBytes(fieldDataBytes);
                            break;
                        case 203:
                            userName = stringConverter.FromBytes(fieldDataBytes);
                            break;
                        case 206:
                            opqueue = stringConverter.FromBytes(fieldDataBytes);
                            break;
                        case 209:
                            userdata = stringConverter.FromBytes(fieldDataBytes);
                            break;
                        case 210:
                            status = stringConverter.FromBytes(fieldDataBytes);
                            break;
                        case 211:
                            totpages = longConverter.FromBytes(fieldDataBytes);
                            break;
                        case 213:
                            copies = longConverter.FromBytes(fieldDataBytes);
                            break;
                        case 216:
                            openeddate = stringConverter.FromBytes(fieldDataBytes);
                            break;
                        case 217:
                            opentime = stringConverter.FromBytes(fieldDataBytes);
                            break;
                        case 218:
                            jobid = fieldDataBytes;
                            break;
                        case 219:
                            fileid = fieldDataBytes;
                            break;
                    }
                }
                //All field elements that the API returned (that we care about) are loaded.
                //Now do something with the spooled file fields here.
            }
            //Delete the user space
            cwbx.Program qusdltus = new cwbx.Program();
            qusdltus.system = as400;
            qusdltus.LibraryName = "QSYS";
            qusdltus.ProgramName = "QUSDLTUS";
            cwbx.ProgramParameters qusdltusParms = new cwbx.ProgramParameters();
            qusdltusParms.Append("UserSpaceName", cwbrcParameterTypeEnum.cwbrcInput, 20).Value = stringConverter.ToBytes(userSpaceName);
            qusdltusParms.Append("APIError", cwbrcParameterTypeEnum.cwbrcInout, sc2.Length).Value = sc2.Bytes;
            qusdltus.Call(qusdltusParms);
            sc2.Bytes = qusdltusParms["APIError"].Value;
            if (((string)stringConverter.FromBytes(sc2.Fields["messageid"].Value)).Trim().Length > 0)
            {
                //deal with error
                return;
            }
