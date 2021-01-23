    public class LibraryController : ApiController
    {
        [HttpGet]  
        public Book Get(GetBookByIdQuery query)
        {
            // Process query... & return
        }
    }
