    public ActionResult FindSquare(SquareModel model, FormCollection collection)
     {
         if(!string.IsNullOrEmpty(collection["button"]) && collection["button"].ToString() == "Sqr")
         {
             double value = Convert.ToDouble(model.textBox);
             var result = value * value;
             model.textBox1 = Convert.ToString(result);
             return View(model);
         }
     }
