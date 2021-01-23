    @model IEnumerable<Product>
    
    @{
        ViewBag.Title = "All Products";
        Layout = "~/Views/Shared/_Layout.cshtml";
    }
    
    @foreach (var item in Model)
    {
       //Show your products
       <p>item.Name</p>
    }
