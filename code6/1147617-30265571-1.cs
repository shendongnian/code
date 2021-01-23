    public class ProjectsController 
    {
         [Route("doc/{*project}")]
         public ActionResult DocumentationIndex(string project = "") 
         { // ... }
    }
