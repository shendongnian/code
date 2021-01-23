       NewDataSet obj = null;
            string DeviceResponse = "";
            DeviceResponse = "<NewDataSet>" +
                    "    <Table1>" +
                    "      <ID>AN ID</ID>  " +
                    "      <Name>A NAME</Name> " +
                    "    </Table1> " +
                    "    <Table1> " +
                    "      <ID>ANOTHER ID</ID> " +
                    "      <Name>ANOTHER NAME</Name> " +
                    "    </Table1>  " +
                    "    <Table1>" +
                    "       <ID>YET ANOTHER ID AND SO ON</ID> " +
                    "       <Name>YET ANOTHER NAME AND SO ON</Name>" +
                    "    </Table1> " +
                    "  </NewDataSet> ";
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(NewDataSet));
                using (TextReader reader = new StringReader(DeviceResponse))
                {
                    obj = (NewDataSet)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
 
            }
            //if Successful
            string id = obj.Table1[0].ID;
