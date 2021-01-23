    var s = "٣٠.١٢.١٩٨٩";
    var day =   Int32.Parse(string.Join("",
                            s.Split('.')[0].Select(c => char.GetNumericValue(c)))); // 30
    var month = Int32.Parse(string.Join("",
                            s.Split('.')[1].Select(c => char.GetNumericValue(c)))); // 12
    var year =  Int32.Parse(string.Join("",
                            s.Split('.')[2].Select(c => char.GetNumericValue(c)))); // 1989
    var dt = new DateTime(year, month, day);
    Console.WriteLine(dt.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture)); // 30.12.1989
