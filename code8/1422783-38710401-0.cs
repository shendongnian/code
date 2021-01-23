    @for (int i = 0; i < @Model.UserRegions.Count(); i++)
    {
        @Html.LabelFor(m => m.UserRegions[i].IsActive, Model.UserRegions[i].RegionName)
        @Html.HiddenFor(m => m.UserRegions[i].RegionId)
        @Html.CheckBoxFor(m => m.UserRegions[i].IsActive)
        @Html.RadioButtonFor(m => m.UserRegions[i].DefaultRegion, 
                               Model.UserRegions[i].RegionId, new { @Name = "SelectedRegion" })
       
    }
