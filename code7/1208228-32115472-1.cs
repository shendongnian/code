    public class CustomJsonResult : JsonResult
    {
      public override void ExecuteResult(ControllerContext context)
      {
          if (context == null)
          {
              throw new ArgumentNullException("context");
          }
          HttpResponseBase response = context.HttpContext.Response;
          if (!string.IsNullOrEmpty(this.ContentType))
          {
            response.ContentType = this.ContentType;
          }
          else
          {
            response.ContentType = "application/json";
          }
          if (this.ContentEncoding != null)
          {
            response.ContentEncoding = this.ContentEncoding;
          }
          if (this.Data != null)
          {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new [] { new DateTimeConverter () });
            response.Write(serializer.Serialize(this.Data));
          }
      }
    }
