    .Items(items =>
    {
        foreach (var tab in Model.MyTabs) {
            // any logic you need here, for example 
           items
              .Add()
              .Text(tab.Name)
              .HtmlAttributes(new { id = tab.Id.ToString() })
              .Content(@Html.Partial("MyTabView", tab.Model).ToHtmlString());
        }
    }
