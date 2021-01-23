    var data = listBox1.Items
      .OfType<String>()
      .Select(line => line.Split(new Char[] {'\t', ' '},
                                 StringSplitOptions.RemoveEmptyEntries))
      .Select(items => new {
         CallType = items[0],
         Source = items[1],
         Designation = items[2],
         At = DateTime.ParseExact(items[3], "d/M/yyyy", CultureInfo.InvariantCulture) + 
              TimeSpan.Parse(items[4]),
         Duration = TimeSpan.Parse(items[5]) 
       });
