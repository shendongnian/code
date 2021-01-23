    @model List<GridTest1.Models.FileModel>
    
    @{
        ViewBag.Title = "Files";
        WebGrid grid = new WebGrid(Model);
    }
    
    @grid.GetHtml(columns: new[] {
             grid.Column("FileID"),
             grid.Column("UserID"),
             grid.Column("FileName"),
             grid.Column("AddedOn"),
        })
