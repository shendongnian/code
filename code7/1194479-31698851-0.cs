    var objlist =(from m in Contex.GB_Material
    from vv in Contex.WF_VideoVersion.Where(x=>x.MaterialID =m.MaterialID ).DefaultIfEmpty()
    from se in Contex.SP_ScheduleEvent.Where(x=>x.MaterialName =m.MaterialName ).DefaultIfEmpty()
    from s in Contex.SP_Schedule .Where(x=>x.ScheduleID =se.ScheduleID)
    from c in Contex.GB_Channel .Where(x=>x.ChannelID =s.ChannelID )
    WHERE m.MaterialName.ToLower().Contains("foo") || m.MaterialTitle.ToLower() .Contains("foo")
    select new{  m.MaterialId, m.MaterialName, m.MaterialTitle, vv.NearestTXDate, c.ChannelName}).ToList();
