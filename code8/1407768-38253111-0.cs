    var widgets = db.Updates
              .Where(c => c.Sold.Equals(false))
              .GroupBy(c => c.widgetType)       
          .Select(x => x.OrderByDescending(y => y.TimeStamp).First()).ToList();
           widgetGrid.DataSource = widgets;
           widgetGrid.DataBind();
