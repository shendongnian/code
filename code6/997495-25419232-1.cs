    var t = string.Join(",",
                     from g in "2,4,5".Split(new char[] { ',' })
                     select Enum.GetName(typeof(DayOfWeek), Convert.ToInt32(g)));
            Response.Write(t);
 
