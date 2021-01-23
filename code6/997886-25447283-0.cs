    foreach(var item in SourceList)
        {
            int newYear = Convert.ToInt32(item.Year.ToString().Substring(0,2) + item.Day.ToString());
            DateTime result = new DateTime(newYear, item.Month, 10);
            ResultList.Add(result);
        }
