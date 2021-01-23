     @{
        var Category = "";
        var AltCategory = ""; 
    
        var db = Database.Open("Inventory");
    
        if(IsPost){
            Category = Request.Form["ListCategory"];
            AltCategory = Request.Form["AltCategory"];
            bool CategoryCheckbox = Request["CategoryCheckbox"].AsBool(); 
    
            if(CategoryCheckbox){
                Funcs.AddNewProduct(Category);
            }
            else{
                Funcs.AddNewProduct(AltCategory);
            }
            Response.Redirect("~/Members/Products");}
    } 
