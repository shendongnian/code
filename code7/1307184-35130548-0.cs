    public static class SpecialFunctions
    {
        public static void DoSomethingWithInstanceVariable(DataSet files, DataTable myFile)
        {
            DataColumn col = files.dt.Columns["Pfad"];
            foreach (DataRow row in Files.dt.Rows)
            {
                OleDocumentProperties myFile = new DSOFile.OleDocumentProperties();
                myFile.Open(@"" + row[col] + "", false, DSOFile.dsoFileOpenOptions.dsoOptionDefault);
                foreach (DSOFile.CustomProperty property in myFile.CustomProperties)
                    if (property.Name == "Überarbeitet")
                    {
                        MessageBox.Show("Gefunden");
                    }
                myFile.Close();
            }
        }
    }
