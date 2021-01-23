        private void createAttendance()
        {
            try
            {
                txtStatus.ResetText();
                txtStatus.Text += "Creating Attendance file. Please wait.";
                string destination = (@"C:\asdf\Attendance.csv");
                barStatus.Caption = "Processing Attendance file. Please wait.";
                if (File.Exists(destination))
                    File.Delete(destination);
                var validOnlineEntries = File.ReadAllLines(@"C:\asdf\online.csv");//read online file
                                                                                  //var validOnlineEntries = onlineEntries.Where(l => !l.Contains("(")); //remove first line
                var onlineRecords = validOnlineEntries.Select(r => new Attendance()
                {
                    Id = (r.Split(new[] { "," }, StringSplitOptions.None)[0] + ",202" + "," + txtYear.Text),
                    TimeInMinutes = int.Parse(r.Split(new[] { "," }, StringSplitOptions.None)[1]),
                    Date = r.Split(new[] { "," }, StringSplitOptions.None)[2],
                }).ToList();//populate Attendance class
                var validOfflineEntries = File.ReadAllLines(@"C:\asdf\offline.csv"); //read online file
                                                                                     //var validOfflineEntries = offlineEntries.Where(l => !l.Contains("(")); //remove first line
                var offlineRecords = validOfflineEntries.Select(r => new Attendance()
                {
                    Id = (r.Split(new[] { "," }, StringSplitOptions.None)[0] + ",202" + "," + txtYear.Text),
                    TimeInMinutes = int.Parse(r.Split(new[] { "," }, StringSplitOptions.None)[1]),
                    Date = r.Split(new[] { "," }, StringSplitOptions.None)[2],
                }).ToList();//populate Attendance class
                var commonRecords = (from n in onlineRecords
                                     join f in offlineRecords on new { n.Date, n.Id } equals new { f.Date, f.Id } //if Date and Id are equal
                                     select new { n.Id, TimeInMinutes = (n.TimeInMinutes + f.TimeInMinutes), n.Date }).OrderBy(x => x.Id).Distinct().ToList(); //add Online and Off line time
                var newRecords = commonRecords.Select(r => new Attendance()
                {
                    Id = r.Id,
                    TimeInMinutes = r.TimeInMinutes,
                    Date = r.Date,
                }).ToList(); //Populate attendance again. So we can call toString method
                onlineRecords.AddRange(offlineRecords); //merge online and offline
                var recs = onlineRecords.Distinct().Where(r => !newRecords.Any(o => o.Date == r.Date && o.Id == r.Id)).ToList(); //remove already added items from merged online and offline collection
                newRecords.AddRange(recs);//add filtered merged collection to new records
                newRecords = newRecords.OrderBy(r => r.Id).ToList();//order new records by id
                StreamWriter Attendance = new StreamWriter(destination);
                //Attendance.Write("SIS_NUMBER,SCHOOL_CODE,SCHOOL_YEAR,ABSENCE_DATE,ABSENCE_REASON1,ABSENCE_REASON2,MINUTES_ATTEND,NOTE,ABS_FTE1,ABS_FTE2" + Environment.NewLine);
                Attendance.Write("SIS_NUMBER,SCHOOL_CODE,SCHOOL_YEAR,MINUTES_ATTEND,ABSENCE_DATE,ABSENCE_REASON2,ABSENCE_REASON1,NOTE,ABS_FTE1,ABS_FTE2" + Environment.NewLine);
                Attendance.Dispose();
                File.AppendAllLines(destination, newRecords.Select(l => l.ToString()).ToList()); //write new file.
                
                Convert_CSV_To_Excel();
            }
            catch(Exception ex)
            {
                barStatus.Caption = ("ERROR: "+ex.Message.ToString());
            }
        }
