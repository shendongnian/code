    foreach (KeyValuePair<int, int> weekAndYear in @ViewBag.WeekAndYears)
        {
            int key = int.Parse(weekAndYear.Value + "" + weekAndYear.Key);
                    
            bool exist = ((Dictionary<int, Object>)ViewBag.Menus).ContainsKey(key);
    }
