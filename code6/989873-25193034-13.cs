     public class BookController : ApiController{
         //where author is a letter(a-Z) with a minimum of 5 character and 10 max.      
        [Route("html/{id}/{newAuthor:alpha:length(5,10)}")]
        public Book Get(int id, string newAuthor){
            return new Book() { Title = "SQL Server 2012 id= " + id, Author = "Adrian & " + newAuthor };
        }
       [Route("json/{id}/{newAuthor:alpha:length(5,10)}/{title}")]
       public Book Get(int id, string newAuthor, string title){
           return new Book() { Title = "SQL Server 2012 id= " + id, Author = "Adrian & " + newAuthor };
       }
    ...
