    @model MenuVM
    @using (Html.BeginForm())
    {
        @Html.TextBoxFor(m => m.Name)
        @Html.TextBoxFor(m => m.AmountPersons )
        for(int i = 0; i < Model.Dishes.Count; i++)
        {
            <div>
                @Html.HiddenFor(m => m.Dishes[i].ID)
                @Html.HiddenFor(m => m.Dishes[i].Name)
                @Html.CheckBoxFor(m => m.Dishes[i].IsSelected)
                @Html.LabelFor(m => m.Dishes[i].IsSelected, Model.Dishes[i].Name)
            </div>
        }
        <input type="submit" value="Create" />
    }
