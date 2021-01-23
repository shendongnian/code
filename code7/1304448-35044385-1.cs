    [RoutePrefix("api/Empleados")]   
    public class EmpleadosController : ApiController {
       
        [Route("", Name="Empleados")]
        [HttpGet]
        public IHttpActionResult GettblEmpleados(int page, int pageSize) {
            var query = db.SPEmpleadosIntranet().ToList();
    
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
    
            var urlHelper = new UrlHelper(Request);
            var prevLink = page > 0 ? urlHelper.Link("Empleados", new { page = page - 1, pageSize = pageSize }) : "";
            var nextLink = page < totalPages - 1 ? urlHelper.Link("Empleados", new { page = page + 1, pageSize = pageSize }) : "";
    
            var results = query
            .Skip(pageSize * page)
            .Take(pageSize)
            .ToList();
    
            return Ok(query);
        }
    }
