    private int newCategoryId;
    public void myForm_InsertItem()
        {            
            var item = new A.Models.Category();
            CategoryContext db = new CategoryContext();            
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here
                db.Category.Add(item);
                db.SaveChanges();
                //item.CategoryID is present from this point
                newCategoryId = item.CategoryId; // presumably it's called categoryId
            }
        }
    
    protected void myForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
         Response.RedirectToRoute(GetRouteUrl("CategoryEdit", new {CategoryID = newCategoryId}));            
    }
