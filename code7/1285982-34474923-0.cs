    Dictionary<string,string> dictionary;
    //[...]
    string output = "";
    foreach(string key in dictionary.Keys)
    {
        output += "\nKey: \""+key+"\" Value: \""+dictionary[key]+"\"";
    }
    MessageBox.Show(output);
