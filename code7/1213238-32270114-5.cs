    public class YourController
    {
       ...
       public ActionResult Edit(int id)
       {
          Book book = ctx.Books.Find(id);
          var viewModel = new EditBookViewModel()
          {
             BookID = book.BookID,
             Name = book.Name
          }
          return View(viewModel);
       }
    
       [HttpPost]
       public ActionResult Edit(EditBookViewModel viewModel)
       {
          if (ModelState.IsValid)
          {
             var model = ctx.Books.Find(model.BookID);
             viewModel.Name = model.Name;
             ctx.SaveChanges();
          }
          return RedirectToAction("Index");
       }
       ...
    }
