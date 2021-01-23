        var onlineEntries = File.ReadAllLines(@"C:\online.txt");//read online file
        var validOnlineEntries = onlineEntries.Where(l => !l.Contains("(")); //remove first line
        var onlineRecords = validOnlineEntries.Select(r => new Attendance()
        {
            Id = int.Parse(r.Split(new[] {","}, StringSplitOptions.None)[0]),
            TimeInMinutes = int.Parse(r.Split(new[] {","}, StringSplitOptions.None)[1]),
            Date = r.Split(new[] {","}, StringSplitOptions.None)[2],
        }).ToList();//popultae Attendance class
        var offlineEntries = File.ReadAllLines(@"C:\offline.txt"); //read online file
        var validOfflineEntries = onlineEntries.Where(l => !l.Contains("(")); //remove first line
        var offlineRecords = validOfflineEntries.Select(r => new Attendance()
        {
            Id = int.Parse(r.Split(new[] { "," }, StringSplitOptions.None)[0]),
            TimeInMinutes = int.Parse(r.Split(new[] { "," }, StringSplitOptions.None)[1]),
            Date = r.Split(new[] { "," }, StringSplitOptions.None)[2],
        }).ToList();//popultae Attendance class
        var commonRecords = (from n in onlineRecords
                            join f in offlineRecords on new {n.Date, n.Id } equals new {f.Date, f.Id} //if Date and Id are equal
                            select new { n.Id, TimeInMinutes = (n.TimeInMinutes + f.TimeInMinutes), n.Date }).OrderBy(x => x.Id).Distinct().ToList(); //add Online and Off line time
        var newRecords = commonRecords.Select(r => new Attendance()
        {
            Id = r.Id,
            TimeInMinutes = r.TimeInMinutes,
            Date = r.Date,
        }); //Poulate attendance again. So we can call toString method
        File.WriteAllLines(@"C:\newFile.txt", newRecords.Select(l => l.ToString()).ToList()); //write new file.
