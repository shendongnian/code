    DocX document = DocX.Load("C:\\Users\\phil\\Desktop\\text.docx");
    bool flag = false;
    List<List<string>> list1 = new List<List<string>>();
    List<string> list2 = new List<string>();
    foreach (Novacode.Paragraph item in document.Paragraphs)
    {
        //use this if you need whole text of a paragraph
        string paraText = item.Text;
        var result = paraText.Split(' ');
        int count = 0;
        list2 = new List<string>();
        //use this if you need word by word
        foreach (var data in result)
        {
            string word = data.ToString();
            if (word.Contains("@@DELETEBEGIN")) flag = true;
            if (word.Contains("@@DELETEEND"))
            { 
                flag = false;
                list2.Add(word);
            }
            if (flag) list2.Add(word); 
            count++;
        }
        list1.Add(list2);
    }
    for (int i = 0; i < list1.Count(); i++)
    {
        string temp = "";
        for (int y = 0; y < list1[i].Count(); y++)
        {
            if (y == 0) 
            {
                temp = list1[i][y];
                continue;
            }
            temp += " " + list1[i][y];                   
        }
        if (!temp.Equals("")) document.ReplaceText(temp, "");
    }
    document.Save();
