        @using TOTestMgmt
        @model TOTestMgmt.Models.MaintModel
        
        @using (Html.BeginForm("InsertDataSet", "DataSetMaint", FormMethod.Post))
        {
            if (Model != null && Model.SelectedFields!= null)
            {                           
                for (int i = 0; i < Model.SelectedFields.Count; i++)
                {
                   @Html.HiddenFor(model => Model.SelectedFields[i].Id, new { id = "kevtest" + i })
                   @Html.HiddenFor(model => Model.SelectedFields[i].ColumnOrder, new { id = "kevtestColumn" + i }))                
                }
            }                
        }
