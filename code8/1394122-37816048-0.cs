    string[] values = Acode.Split(',');
    List<Test> tst= new List<Test>;
    foreach (string a in values)
    {
        tst.AddRange(entities.Test.Where(g => (g.TCode == Convert.ToInt16(a))));
    }
    return tst;
