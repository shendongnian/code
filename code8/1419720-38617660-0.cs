    // this is a viewmodel intended for a particular view, for example AddProductSubset.chtml
    public class AddProductSubsetViewModel
    {
        public int UniqueID {get; set;}
        public string ProductName {get; set;}
        // add other properties you will be updating from the entity model
        // you can also add properties from other entities or things only needed by the view
    }
    [HttpPost]
    public ActionResult AddProductSubset(AddProductSubsetViewModel vm)
    {
        if (ModelState.IsValid)
        {
            // map your viewmodel to the entity model. See automapper.
            var product = new Product 
            {
                UniqueID = vm.UniqueID,   // unless this is identity, then omit
                ProductName = vm.ProductName,
                otherfield = vm.otherfield,
                ...
            }
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index")
        }
        return View(vm);
    }
