    public ActionResult Details(int id)
    {
       var book=db.Books.FirstOrDefault(s=>s.Id==id);
       if(book!= null)
       {
         var vm=new BookViewModel { Id=id,Title=book.Title,ShelveId=book.BookShelveId};
         return View(vm);
       }
       return View("NotFound");
    }
