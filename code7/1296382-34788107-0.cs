    if (poi1.ContainsKey(txt))
    {
        List<string> points = poi1.GetValue(txt);
        Combo_list2.Items.Clear();
        Combo_list2.Items.AddRange(points.ToArray());
    }
