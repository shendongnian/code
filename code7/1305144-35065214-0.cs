    public ActionResult GenerateChart(List<Bar> model)
    {
        var chart = new System.Web.Helpers.Chart(400, 200)
            .AddTitle("Title")
            .AddSeries(
                name : "name",
                xValue : model.Select(m => m.BarA).ToArray(),
                yValues : model.Select(m => m.BarB).ToArray())
        .GetBytes("jpeg");
    
        return File(chart, "image/jpeg");
    }
