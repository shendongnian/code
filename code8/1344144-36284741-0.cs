    public class MyResult:ActionResult {
      private JObject _data;
      public MyResult(object data) {
        _data=JObject.FromObject(data);
      }
      public override ExecuteResult(ControllerContext context) {
        var response=context.HttpContext.Response;
    	response.ContentType="application/json";
    	response.Write(_data.ToString());
      }
    }
