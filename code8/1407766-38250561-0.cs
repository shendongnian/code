             var widgets = db.Updates
            .GroupBy(c => c.widgetType)
            .SelectMany(s => s)
            .Where(c => c.Sold.Equals(false))
            .OrderByDescending(x => x.TimeStamp)
            .Select(y=>y.First());
        var list = new List<Update>() {widgets};
            widgetsGrid.DataSource = list;            
            widgetsGrid.DataBind();
