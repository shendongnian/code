    @using (Html.BeginForm("Create", "Item", FormMethod.Post)) 
    {
       <div>
        @Html.LabelFor(model => model.AvailableColours)
        @for(var i = 0; i < Model.AvailableColours.Count; i++)
        {    
            @Html.HiddenFor(m => Model.AvailableColours[i].ID)
            @Html.HiddenFor(m => Model.AvailableColours[i].Description)
            @Html.CheckBoxFor(m => Model.AvailableColours[i].Checked)
            @Model.AvailableColours[i].Description<br/>
         }
        </div>
    <input type="submit" value="Submit" />
    }
