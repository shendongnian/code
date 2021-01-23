     private void csvParse(string path)
        {
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.Delimiters = new string[] { "," };
                Dictionary<string, List<string>> uniqueContacts = new Dictionary<string, List<string>>();
                while (!parser.EndOfData)
                {
                    string[] parts = parser.ReadFields();
                    if (parts == null || parts.Count() != 2)
                    {
                        break;
                    }
                    //if contact id not present in dictionary add
                    if (!uniqueContacts.ContainsKey(parts[0]))
                        uniqueContacts.Add(parts[0],new List<string>());
                    //now there's definitely an existing contact in dic (the one 
                    //we've just added or a previously added one) so add to the                   
                    //list of strings for that contact
                    uniqueContacts[parts[0]].Add(parts[1]);
                }
                //now do something with that dictionary of unique user names and
                // lists of strings, for example dump them to console in the 
                //format you specify:
                foreach (var contactId in uniqueContacts.Keys)
                {
                    
                    var sb = new StringBuilder();
                    sb.Append($"contactId, ");
                    foreach (var bit in uniqueContacts[contactId])
                    {
                        sb.Append(bit);
                        if (bit != uniqueContacts[contactId].Last())
                            sb.Append(", ");
                    }
                    Console.WriteLine(sb);
                }
            }
        }
