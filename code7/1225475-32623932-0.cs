    string inp = File.ReadAllText("inp.txt");
    string result1 = "";
    TxtWebAdd.Text = inp;
    var found = TxtWebAdd.Text.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
    foreach(string fn in found)
    {
    	result1 = result1 + Regex.Replace(fn.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Last().ToString(), @"[\d-]", string.Empty) + "\r\n";
    }
