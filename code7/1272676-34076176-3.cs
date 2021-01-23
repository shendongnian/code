    public void UpdateEndValues(List<TypeLogSettingsCellItem> list)
     {
        int highestEndValue = list.Max (x => x.End);
        for(int i = 0; i < list.Count -1; i++)
        {
            list[i].End = list[i+1].Start;
        }
        list.Last.End = (list.Last.Start > highestEndValue) ? list.Last.Start : highestEndValue;
    }
