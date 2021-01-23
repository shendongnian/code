    private void csvParse(string path)
            {
                using (TextFieldParser parser = new TextFieldParser(path))
                    {
                        parser.Delimiters = new string[] { "," };
                        string[] oldParts = new string[] { string.Empty };
                        while (!parser.EndOfData)
                        {
                            string[] parts = parser.ReadFields();
                            if (parts == null || parts.Length < 1)
                            {
                                break;
                            }
                            if (oldParts[0] == parts[0])
                            {
                                 // concat logic goes here
                            }
                            else
                            {
                                contact.ContactId = parts[0];
                            }
                            long nextLine;
                            nextLine = parser.LineNumber+1;
                            oldParts = parts;
    //if line1 parts[0] == line2 parts[0] etc.
                        }
                    }
                }
