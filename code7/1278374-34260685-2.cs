    public List<bool> aFaerie_Charm()
    {
        var allylist = new List<Obj_AI_Hero>();
        allylist.AddRange(HeroManager.Allies);
        List<bool> z = new List<bool>();
        for (int i = 0; i < allylist.Count; i++) //allylist.count = 4
        {
            z.Add(Items.HasItem((int)ItemId.Faerie_Charm, allylist[i]));
        }
        return z;
    }
