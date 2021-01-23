    public ActionResult Index(int? IDnumber, string LnameString, string FnameString, string bookGenre,string searchString)
    {
        //LINQ  query to select books
        var books = from m in db.Book
                    select m;
        //ID Number
        if (IDnumber.HasValue)
        {
            books = books.Where(x => x.BookID == IDnumber.Value);
        }
    ...
    }
