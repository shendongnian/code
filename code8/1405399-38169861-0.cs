    <body>
    @using (Html.BeginForm())
    {
        List<SelectListItem> listItems = new List<SelectListItem>();
        listItems.Add(new SelectListItem
        {
            Text = "Example1",
            Value = "Example1"
        });
        listItems.Add(new SelectListItem
        {
            Text = "Example2",
            Value = "Example2",
            Selected = true
        });
        listItems.Add(new SelectListItem
        {
            Text = "Example3",
            Value = "Example3"
        });
        <div>
            @Html.LabelFor(m => m.Price)
            @Html.TextBoxFor(m => m.Price)
            @Html.ValidationMessageFor(m => m.Price)
        </div>
        <div>
            @Html.LabelFor(m => m.SelectedLeague)
            @Html.DropDownListFor(m => m.SelectedLeague, listItems)
            @Html.ValidationMessageFor(m => m.SelectedLeague)
        </div>
        <div>
            @Html.LabelFor(m => m.SelectedLeagueDivision)
            @Html.DropDownListFor(m => m.SelectedLeagueDivision, Model.LeagueDivisionList)
            @Html.ValidationMessageFor(m => m.SelectedLeagueDivision)
        </div>
        <input type="submit" value="save" />
    }
