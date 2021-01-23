    var hitfinderTable = document.All.Where(m => m.Id == "hitfindertable").First() as AngleSharp.Dom.Html.IHtmlTableElement;
    
    foreach (var row in hitfinderTable.Rows)
    {
    	var artistName = row.Cells[2].TextContent;
    }
