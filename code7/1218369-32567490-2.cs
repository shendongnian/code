    @model IPagedList<OnlineShoppingStore.Domain.Entities.Product>
    @using PagedList;
    @using PagedList.Mvc;
    @{
    ViewBag.Title = "Products";
    }
    @foreach (var p in Model)
    {
    @Html.Partial("ProductSummary",p)
   
    }
    @{
    
    }
    <div>
    
    @Html.PagedListPager(Model, page => Url.Action("List", new {page,      Filter_Value = ViewBag.FilterValue }))
    
    Page @(Model.PageCount < Model.PageNumber ? 0 : Model.PageNumber) of @Model.PageCount
