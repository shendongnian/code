    public class SimpleModule : Nancy.NancyModule
    {
            Get["/State/"] = parameters =>
            {
                string Json = TheSerializer.Serialize(myobject);
                return Response.AsText(Json);
                // return Response.AsJson(myobject);
            };        
    }
