    public class ScriptController: Controller
    {
      public ActionResult GetServices(){
       string file= File.ReadAllText(Server.MapPath("~dist/services.js"));
       //modify the file to inject data or 
       var result = new JavaScriptResult();         
       result.Script = file;
       return result;     
    }
