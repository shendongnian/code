    System.IO.StreamReader YourIniFile = new System.IO.StreamReader("yourIniFilePath");
    string fileText = YourIniFile.ReadToEnd();  
    string[] splitText = fileText.Split(new string[] {"\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries);
    ILookup<string, string> ini = splitText.ToLookup(key=> key.Substring(0, key.IndexOf("=")),
                                   value => value.Substring(value.IndexOf("=")));
