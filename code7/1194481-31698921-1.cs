    (from m in context.GB_Material
    join vv in context.WF_VideoVersion  on new {m.MaterialID }
                                                   equals new { vv.MaterialID } into vv_join
                                                 from vv in vv_join.DefaultIfEmpty()
    join se in context.SP_ScheduleEvent  on new {m.MaterialName }
                                                   equals new { se.MaterialName } into se_join
                                                 from se in se_join.DefaultIfEmpty()
     join s in context.SP_Schedule on new {se.ScheduleID } equals new { s.ScheduleID}
    join c in context.GB_Channel on new { s.ChannelID } equals new { c.ChannelID }
                                                 
                                                 where
                                                  m.MaterialName.ToLower().Contains("foo") || m.MaterialTitle.ToLower().Contains("foo")
                                                  
                                                 select new
                                                 {
                                                     m.MaterialId, m.MaterialName, m.MaterialTitle, vv.NearestTXDate, c.ChannelName
    
                                                 })
