        public void LoadCommand(string commandName)
        {
            bool commandFound = false;
            foreach (string file in Directory.GetFiles("/Users/lcharlton/Documents/SQLCheatSheetProto/SQLCheatSheetProto/SQLCheatSheetProto/SQLCheatSheetFiles"))
            {
                StreamReader reader = new StreamReader(file);
                bool endOfFile = false;
                while (!commandFound && !endOfFile)
                {
                    string s = reader.ReadLine();
                    string[] items = s.Split(new[] { '}' }, StringSplitOptions.RemoveEmptyEntries);
                    if (items.Length > 0)
                    {
                        if (items[0].ToLower() == commandName)
                        {                              
                            //Searches through every .csv in the specified path and returns the first command that has a command name mathcing what the user specified.
                            SyntaxText.Text = items.Length > 1 ? items[1] : string.Empty;
                            DescriptionText.Text = items.Length > 2 ? items[2] : string.Empty;
                            ExampleText.Text = items.Length > 3 ? items[3] : string.Empty;
                            DescriptionText.Font = SyntaxText.Font;
                            commandFound = true;
                        }
                    }
                    if (reader.EndOfStream)
                    {
                        reader.Close();
                        endOfFile = true;
                    }
                }
            }
        }
