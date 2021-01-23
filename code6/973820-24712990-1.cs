    public void Add(Push p){
        int i = 0;
        for (; i < Settings.PushCol.Count; i++)
        {
            if (Settings.PushCol[i].Created > p.Created)
                break;
        }
        Settings.PushCol.Insert(i, p);
    }
