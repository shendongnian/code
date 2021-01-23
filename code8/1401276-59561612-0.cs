    [HttpGet]
    [Route("/Product/GetProduct/{id}")]
     public ActionResult GetProduct(string id)
     {
          ViewBag.CaseId = id;
          return View();
     }
    
    
     <a  asp-controller="Product" asp-action="GetProduct" asp-route-id="@item.id" >ProductName</a>
