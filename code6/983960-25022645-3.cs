    @model MvcApplication1.Models.ViewModel
            <ol>
            @foreach (var item in Model.Links)
            {
                <li>
                @Html.ActionLink("viewedName", "ChemicalClass", new { mystring = item })
                </li?
            }
            </ol>
