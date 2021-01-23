    @model Item
    <span>@Model.ItemName</span>
    <ul>
        @if (Model.Children?.Any() ?? false)
        {
            foreach (var child in Model.Children)
            {
                <li>
                    @Html.Partial("RecursivePartial", child)
                </li>
            }
        }
        else
        {
            <li>
                No items available for @Model.ItemName.
            </li>
        }
    </ul>
