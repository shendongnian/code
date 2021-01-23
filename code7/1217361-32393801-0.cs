                using (TextFieldParser parser = new TextFieldParser(@"..\Debug\data\IrisData.csv"))
            {
                parser.SetDelimiters(new String[] { "," });
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    // fields will contain every seperated cell
                }
            }
