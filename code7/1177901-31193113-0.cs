    var conditions = new[] { pFirstname, pLastname};
    var seconds = new List<string>();
    var webGet = new HtmlAgilityPack.HtmlWeb();
    var doc = webGet.Load("http://www.birthday.no/sok/?f=Frank&l=Anderson");
    var a_nodes = doc.DocumentNode.Descendants("a").Where(a => a.HasChildNodes && a.ChildNodes[0].Name == "b");
    var res = a_nodes.Select(a => a.ChildNodes[0].InnerText).Where(b => conditions.All(condition => b.Contains(condition))).ToList();
    foreach (var name in res)
    {
        var splts = name.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
        if (splts.GetLength(0) > 2) // we have 3 elements at the least
           seconds.Add(name.Trim().Substring(name.Trim().IndexOf(" ") + 1, name.Trim().LastIndexOf(" ") - name.Trim().IndexOf(" ") - 1));
    }
