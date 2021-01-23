    public ActionResult PrepareChartData(int id)
    {
        List<FlotSeries> _flotSeries = new List<FlotSeries>();
        var deviceChannels = db.DeviceChannels
                            .Include(c=>c.Channel)
                            .OrderBy(c=>c.ChannelID)
                            .Where(c=>c.DeviceID==id);
        foreach (var dc in deviceChannels)
        {
            FlotSeries fs = new FlotSeries();
            fs.data = new List<double[]>();
            fs.label = dc.Channel.Description;
            var channelDatas = db.ChannelDatas
                            .OrderBy(c => c.DataDateTime)
                            .Where(c => c.DeviceChannelID == dc.DeviceChannelID);
            foreach (var q in channelDatas)
            {
                fs.data.Add( new Double[] {(q.DataDateTime - new DateTime(1970, 1, 1)).TotalSeconds * 1000, q.Value }  );   
            }
            _flotSeries.Add(fs);
        }
        return Json(_flotSeries, JsonRequestBehavior.AllowGet);
    }
