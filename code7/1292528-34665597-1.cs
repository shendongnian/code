    @model ViewModelEditManuscript
    @using (Html.BeginForm())
    {    
        var i = 0;
        foreach (var item in @Model.Authors)
        {
            @Html.TextBox("Authors[" + i+ "].Author.Id",item.Author.Id)
          
            i++;
        }
        <input type="submit"/>
    }
