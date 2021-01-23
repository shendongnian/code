     public String getTimelineChart(DateTime tsInic, DateTime tsEnd, string typeReq = "normal")
    {
            var rep = new AfterSalesWind.Models.OM_Repository();
            var chart = rep.getTimelineChart(tsInic, tsEnd);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            chart.SaveImage(ms, ChartImageFormat.Png);
            return Convert.ToBase64String(ms.ToArray());
    }
