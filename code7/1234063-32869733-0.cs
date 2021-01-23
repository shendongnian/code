    @using (Html.BeginForm("DepartmentReportSelection", "Reports", new { ClientID = Model.inputParameters[0], SupplierID = Model.inputParameters[1], StatusCategoryID = Model.inputParameters[2] }, FormMethod.Post)) {
                @Html.DropDownListFor(m => m.CategoryTypeOptions.First().StatusCategoryID, new SelectList(Model.CategoryTypeOptions, "StatusCategoryID", "StatusCategoryDesc"), new { @class = "GRDropDown", @id = "ReportDD" })
                <input type="hidden" name="ClientID" value="@Model.ClientID" />
                if (Model.TypeOfReport == 1) {
                    for (int i = 0; i < Model.inputReviewPeriodIDs.Length; i++) {
                        <input type="hidden" name="ReviewPeriodID" value="@Model.inputReviewPeriodIDs[i]" />
                    }
    
                    <input type="hidden" name="SupplierID" value="@Model.SupplierData" />
                }
                else if (Model.TypeOfReport == 2) {
                    for (int i = 0; i < Model.inputReviewPeriodIDs.Length; i++) {
                        <input type="hidden" name="ReviewPeriodID" value="@Model.inputReviewPeriodIDs[i]" />
                    }
                }
                else {
                    <input type="hidden" name="SupplierID" value="@Model.SupplierData" />
                }
                
                <button type="submit" value="Submit" class="btn btn-default StandardButton">Filter</button>
            }
