    pubic static void SpecialFuntion_1(DataTable table)
    {
        foreach (DataRow row in table.Rows)
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
