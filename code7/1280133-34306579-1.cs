    public ActionResult Getitems()
            {
                var itemList = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Text = "RICE",
                    Value = "RICE"
                    },
                     new SelectListItem
                    {
                        Text = "WHEAT",
                    Value = "WHEAT"
                    }
                };
    
    
    
                ViewBag.ItemList = new MultiSelectList(itemList, "Value", "Text");
                return View();
            } 
