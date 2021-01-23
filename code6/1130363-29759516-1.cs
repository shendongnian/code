            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            string file = "C:\\Hello World.docx";
            Microsoft.Office.Interop.Word.Document doc = word.Documents.Open(file);
            // look for a specific type of Field (there are about 200 to choose from).
            foreach (Field f in doc.Fields)
            {
                if (f.Type == WdFieldType.wdFieldDate)
                {
                    //do something
                }
            }
            // example of the myriad properties that could be associated with "document settings"
            WdProtectionType protType = doc.ProtectionType;
            if (protType.Equals(WdProtectionType.wdAllowOnlyComments))
            {
                //do something else
            }
