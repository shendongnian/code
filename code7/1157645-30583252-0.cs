    public class BookDTO
    {
        public int BookID {get;set;}
    	public string Title {get;set;}
    	public string Description {get;set;}
    	public int ISBN {get;set;}
    	public string AuthorName{get;set;}
    }
    
    public HttpResponseMessage GetBooks()
    {
      //ideally you'd be using a repository abstraction instead of db directly
      //but I want to keep this simple.
       var books = db.Books.Select(
          book=>new BookDTO(){
             BookID=book.BookID,
    	     Title=book.Title,
    	     Description=book.Description,
    	     ISBN=book.ISBN,
    	     AuthorName=book.Author.Name //<-flattening
       });
       return Request.CreateResponse(HttpStatusCode.OK, books);
    }
