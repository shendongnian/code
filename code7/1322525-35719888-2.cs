    public class NamesController : ApiController
    {
      [HttpGet]
      [ActionName("GET_NAMES")]
      public Drugs_ResponseData Get(string q)
      {
        string[] arrAmpersant = Commonnn.DecodeFrom64(HttpContext.Current.Items("qs_d").ToString()).Split('&');
        Names_obj = new Names();
        return _obj.GetResult(Convert.ToInt32(Commonnn.GetValFromEqual(arrAmpersant[0])));
      }
    }
