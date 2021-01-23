            var date = DateTime.Parse("21.08.2014");
            var nextdate = date.AddDays(1);
            var list = new List<DateTime>();
            for (var i = date; i < nextdate; i = i.AddMinutes(1))
            {
                list.Add(i);
            }
            list.RemoveRange(tempList.Select(o=>o.Date).ToList());
