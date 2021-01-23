    public class BaseController<T>: ApiController
    {
        
        //here you can add whatever dependency injection you may use
        public BaseController(DbContext context) 
        {
            _context = context;  
        }
       
       [HttpPost]
       public IHttpActionResult Add(T data)
       {
           return Ok(_context.Add(data));
       }
       
       [HttpPut]
       public IHttpActionResult Edit(T data)
       {
            _context.Modify(data); //here depends on your ORM or data access layer
            return Ok(data);
       }
       /*other methods you think are necessary in this base controller*/
    }
