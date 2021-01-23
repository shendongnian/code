    public class JSONNetResult: ActionResult
    {
         private readonly JObject _data;
         public JSONNetResult(JObject data)
         {
             _data = data;
         }
         public override void ExecuteResult(ControllerContext context)
         {
             var response = context.HttpContext.Response;
             response.ContentType = "application/json";
             response.Write(_data.ToString(Newtonsoft.Json.Formatting.None));
         }
     }
