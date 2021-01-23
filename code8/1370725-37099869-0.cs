           private void Load()
            {
                TextFieldParser par = new TextFieldParser(FileName);
                par.TextFieldType = FieldType.Delimited;
                par.SetDelimiters(Delimiter);
                while (!par.EndOfData)
                {
                    string[] fields = par.ReadFields();
                    foreach (string field in fields)
                    {
                        Console.WriteLine(field);
                    }
                    //-----------------------------Add -----------------------
                    Player newPlayer = new Player(fields[0], fields[1], fields[2], DateTime.Parse(fields[3]), fields[4], fields[5][0]);
                    players.Add(newPlayer);
                }
                par.Close();
            }
