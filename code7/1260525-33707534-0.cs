    var ageAndDate = from x in db.Person
                        select new Tuple<double, DateTime>(x.Age, x.Date);
    var topFiveAgeWithdate = ageAndDate.OrderByDescending(t => t.Item1).Take(5).ToList();
    List<string> topFiveAge = topFiveAgeWithdate.Select(t => t.Item1.ToString()).ToList();
    List<string> topFiveDate = topFiveAgeWithdate.Select(t => t.Item2.ToShortDateString()).ToList();
