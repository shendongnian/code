    static void LoadMap(string fname)
    {
        string _org = File.ReadAllText("Maps/" + fname + ".txt");
        _org.Split(',');
        string[] _tmp = new string[_org.Length];
        for (int i = 0;i < _org.Length; i++)
        {
            _tmp[i] = _org[i].ToString();
        }
        for (int i = 0;i < _tmp.Length && _tmp[i] != "$"; i += 2)
        {
            mapwidth += 1;
        }
        for (int i = 0;i < _tmp.Length; i++)
        {
            leveldata.Add(_tmp[i]);
        }
    }
