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
    
    
    
                ViewBag.ItemList = new SelectList(itemList, "Value", "Text");
                return View();
            } 
