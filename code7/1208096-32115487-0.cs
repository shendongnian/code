        @using (Html.BeginForm("ExportExcel", null, FormMethod.Post))
        {
            @Html.Hidden("ProjectId", Model.ProjectId)
            @Html.Hidden("ProjectName", Model.ProjectName)
            ...
            @for(int i = 0; i < Model.SelectedSystems.Count(); i++)
            {
                var systemModel = Model.SelectedSystems.ElementAt(i);
                @Html.Hidden("SelectedSystems[" + i + "].Property1", systemModel.Property1)
                @Html.Hidden("SelectedSystems[" + i + "].Property2", systemModel.Property2)
            }
            <input type="submit" value="Export to Excel" />
        }
