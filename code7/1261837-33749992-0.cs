    string lines="";
     FileStream fs1 = new FileStream(@
        "D:\temp.txt", FileMode.OpenOrCreate, FileAccess.Write);
        StreamWriter file1 = new StreamWriter(fs1);
    while ((line = file.ReadLine()) != null) {
        // MessageBox.Show("in while");       
        file1.WriteLine();
        foreach(string word in stopWord) {
            //line = line.Replace(word,Environment.NewLine);
            line = line.Replace(word, "");
            
        }
        lines +=line +Environment.Newline;
    }
        file1.WriteLine(lines);
        file1.Close();
