    List<string> lst = new List<string>();
    lst.Add("0003 India");
    lst.Add("0005 America");
    lst.Add("0004 Japan");
    lst.Add("0001 Sweden");
    lst.Add("0002 Germany");
    lst = lst.OrderBy(item => item.Split(' ').ElementAtOrDefault(1)).ToList();
    // Or if always by the string from position 5 onward then:
    lst = lst.OrderBy(p => p.Substring(5)).ToList();
    lstSearchResult.DataSource = lst;
    lstSearchResult.DataBind();
