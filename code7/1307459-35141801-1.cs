    [HttpPost]
    public JsonResult GetBookDetails(string bookId)
    {
        BookBusiness bk = new BookBusiness();
        var books = bk.GetBookDetails("50000").Select(b => new
        {
            value = b.BookId,
            text = b.BookName  
        };
        return Json(books);
    }
    
