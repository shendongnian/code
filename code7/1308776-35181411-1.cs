    @for (int i = 0; i < Model.Checklist.Count ;i++)
    {
        @Html.DisplayFor(it => it.Checklist[i].Name)
        @Html.HiddenFor(it =>  it.Checklist[i].Id)
        @Html.CheckBoxFor(it =>  it.Checklist[i].Checked)
    }
