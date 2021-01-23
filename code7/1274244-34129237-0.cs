        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Product_Edit(ProductEdit product)
        {
            var user = db.AspNetUsers.Find(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                for (int i = 0; i < product.ListProductFields.Count; i++)
                {
                    var insertproductvalue = new AB_Product_vs_Field
                    {
                        Product_ID = product.Product_ID,
                        Field_ID = product.ListProductFields[i].Field_ID,
                        Field_Value_EN = product.ListProductFields[i].Field_Value_EN,
                        Field_Value_AR = product.ListProductFields[i].Field_Value_AR
                    }); 
                    // Attach and set to modified
                    db.Entry(insertproductvalue).State = System.Data.Entity.EntityState.Modified;
                };
                db.SaveChanges();
