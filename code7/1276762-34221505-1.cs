    @model IEnumerable<AMBIT_CMS_MVC.Areas.Admin.Models.Product>
    
    <ul>
        @foreach (var item in Model)
        {
            <li>@Html.ActionLink(item.Name, "Produkt", new { ProductID = item.ProductID })</li>
        }
    </ul>
