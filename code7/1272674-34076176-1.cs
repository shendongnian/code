    public void UpdateEndValues(List<SettingsCellItem> list)
    {
        int highestEndValue = list.Max(x => x.End)
        for(int i = 0; i < list.Length -1; i++)
        {
            list[i].End = list[i+1].Start;
        }
        list.Last.End = highestEndValue;
    }
