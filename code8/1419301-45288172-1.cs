    //Create a new select list. the variable Imagelist will take on whatever type SelectList.
    
       var Imagelist = new SelectList(
        new List<SelectListItem>
        {
            new SelectListItem { Text = imagename, Value = "Id"},
            new SelectListItem { Text = imagename2, Value = "Id2"},
          
        }, "Value" , "Text");
    
        
        //You can now use this viewbag in your view howevere you want.
          ViewBag.Image = Imagelist.
   
