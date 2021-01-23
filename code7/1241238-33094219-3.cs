    static void LoadMap(string fname)
    {
        string[] _org = File.ReadAllText("Maps/" + fname + ".txt").Split(',');
        foreach (var _tmp in _org)
        {
            if (_tmp != "$")
            {
                mapwidth += 1;
            }
            leveldata.Add(_tmp);
        }
    }
