    Range r = doc.Paragraphs.Add().Range;
     
    string s = string.Join("\n", data.Select(a => string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",a.Item1,a.Item2,a.Item3,a.Item4,a.Item5,a.Item6,a.Item7)));
     
    r.Text = s;
    
    Table t = r.ConvertToTable(Separator: WdTableFieldSeparator.wdSeparateByTabs);
