         @{
                WebGrid grid = new WebGrid(Model);
                List<WebGridColumn> columnsL = new List<WebGridColumn>();
        foreach (ServiceReference1.Column col in ViewBag.ColumnList)
                {
                    WebGridColumn c = new WebGridColumn();
                    c.ColumnName = col.columnName;
                    c.Header = col.columnCaptionValue;
                    c.Format = (item) => @Html.Raw("<div style='word-wrap:hyphenate;height:30px;min-width:" + col.columnWidth + "px'><b style='background-color:palevioletred'>" + item[col.columnName] + "</b></div>");
        
                    columnsL.Add(c);
                }
    }
        <div class="test" style="overflow: scroll;">
                <div style="width:1000px"> 
            @grid.GetHtml(tableStyle: "table table-striped table-bordered", columns: columnsL, caption: ViewBag.GridHeader, headerStyle: "gvHeading")
                </div>
            </div>
