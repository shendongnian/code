        @(Html.Kendo().TabStrip()
        .Name("tabstrip")
        .Items(tabstrip =>
        {
            tabstrip.Add()
                .Text("First Tab")
                .Selected(true)
                .Content(@<text>@Html.Partial("PartialViews/_Main", Model)</text>);
            tabstrip.Add().Text("Second Tab")
                .Content(@<text>@Html.Partial("PartialViews/_Levels", Model)</text>);
            
            tabstrip.Add().Text("Third Tab")
                .Content(@<text>@Html.Partial("PartialViews/_Assigned", Model)</text>);
            
        }))
