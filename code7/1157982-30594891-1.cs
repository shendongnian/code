    @model IEnumerable<DevelopmentNotesProject.Models.PieModel>
    ..
    ...
    ....
        @(Html.Kendo().Chart(Model)
            .Name("chart")
                    .Title(title => title
                        .Text("")
                        .Position(ChartTitlePosition.Bottom))
            .Legend(legend => legend
                .Visible(false)
            )
                       //.DataSource(ds => ds.Read(read => read.Action("displayChart", "Statistics")))
                .Series(series =>
                {
                    series.Pie( model => model.Count,model => model.Language);
                })
    
    
                 
              
            .Tooltip(tooltip => tooltip
                .Visible(true)
                .Format("{0}%")
            )
    
            
        )
