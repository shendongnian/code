            Axapta DynAx = new Axapta();
            AxaptaRecord DynRec;
            string strUserName = "";
            System.Net.NetworkCredential nc = new System.Net.NetworkCredential("", "");
            string tableName = "";
            DynAx.LogonAs(strUserName.Trim(), "", nc, dataAreaId, "en-us","", "");
            try
            {
                using (DynRec = DynAx.CreateAxaptaRecord(tableName))
                {
                    var binData = DynAx.CreateAxaptaObject("Bindata");
                    var loaded = binData.Call("loadFile", path);
                    var data = binData.Call("getData");
                    AxaptaContainer axc = DynAx.CreateAxaptaContainer();
                    axc.Add(data);
                    
                    DynRec.set_Field("ATTACHMENT", axc.get_Item(1));
                    // Commit the record to the database.
                    DynRec.Insert();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                DynAx.Logoff();
            }
