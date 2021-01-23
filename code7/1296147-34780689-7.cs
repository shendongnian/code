        var onlineEntries = File.ReadAllLines(@"c:\online.txt");//read online file
        var validOnlineEntries = onlineEntries.Where(l => !l.Contains("(")); //remove first line
        var onlineRecords = validOnlineEntries.Select(r => new Attendance()
        {
            Id = int.Parse(r.Split(new[] {","}, StringSplitOptions.None)[0]),
            TimeInMinutes = int.Parse(r.Split(new[] {","}, StringSplitOptions.None)[1]),
            Date = r.Split(new[] {","}, StringSplitOptions.None)[2],
        }).ToList();//popultae Attendance class
        var offlineEntries = File.ReadAllLines(@"c:\offline.txt"); //read online file
        var validOfflineEntries = offlineEntries.Where(l => !l.Contains("(")); //remove first line
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
        onlineRecords.AddRange(offlineRecords); //merge online and offline
        var recs = onlineRecords.Distinct().Where(r => !newRecords.Any(o => o.Date == r.Date && o.Id == r.Id)).ToList(); //remove already added items from merged online and offline collection
        newRecords.AddRange(recs);//add filtered merged collection to new records
        newRecords = newRecords.OrderBy(r => r.Id).ToList();//order new records by id
        File.WriteAllLines(@"C:\newFile.txt", newRecords.Select(l => l.ToString()).ToList()); //write new file.
