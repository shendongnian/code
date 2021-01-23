    public void alarmlog(int id)
    {
         AlarmLog log = new AlarmLog();
    
         log.SectorID = "LRD";
         log.LineNo = "L01";
         log.WorkStation = "02";
         log.LMQS = 1;
         log.StaffID = 6;
         log.DateTime = DateTime.Now;
         db.AlarmLogs.Add(log);
         db.SaveChanges();
    }
