    // Create .aspx page, to be our service. 
    public class ControlUpdateService
    {
         protected void Page_Load(object sender, EventArgs e)
         {
              // Use an approach to determine which control type, and model to build.         
              // You would build your object, then use Newtonsoft.Json, to serialize, then
              // return the object, via Response.End(object). 
         }
    }
