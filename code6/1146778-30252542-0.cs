    @Html.ValidationSummary();
    @for (int i = 0; i < Model.MyList.Count(); i++)
    {
        @Html.TextBoxFor(m => m.MyList[i].Description)
        @Html.TextBoxFor(m => m.MyList[i].Amount)
        @Html.ValidationMessageFor(m => m.MyList[i].Description)
        @Html.ValidationMessageFor(m => m.MyList[i].Amount)
    }
