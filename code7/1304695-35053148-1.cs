    const string inFile = "Z:/Daniel/Accounts.txt";
                    const string outFile = "Z:/Daniel/SortedAccounts.txt";
                    string[] contents = File.ReadAllLines(inFile);
                    Array.Sort(contents);
                    File.WriteAllLines(outFile, contents);
                    IEnumerable<string> lines = File.ReadLines("Z:/Daniel/SortedAccounts.txt");
                    foreach (string line in lines)
                    {
                        
                        //First Name
                        string[] data = Regex.Split(line, "[#\\d#]");
                        string accountFirstName = data[0];
                        string accountLastName = data[1];
                        string accountEmail = data[2];
                        
                        //Phone Number
                        string accountNumber = data[3];
                        
                        //Preferred Contact
                        string accountPreferredContact = data[4];
                        //Populate Combobox
                        //accountComboBox.Items.Add(accountLastName + "," + accountFirstName);
                    }
 
