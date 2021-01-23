    @for (int i = 0; i < Model.ColorList.Count; i++)
    {
        @Html.HiddenFor(m => m.ColorList[i].Color_id)
        @Html.CheckBoxFor(m => m.ColorList[i].IsSelected)
        @Html.LabelFor(m => m.ColorList[i].IsSelected, Model.ColorList[i].Color_name)
    }
