        Product product = db.Products.Find(Id);
        var quantity = new List<SelectListItem>();
        for (var i = 1; i <= product.Quantity; i++)
        {
            quantity.Add(new SelectListItem()
            {
                Text = i.ToString(),
                Value = i.ToString()
            }
            ); <-----To what does this belong?
        }
        return Json(quantity, JsonRequestBehavior.AllowGet);
    }
