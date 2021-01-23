    public class OEMaster : BaseClass
    {
    if (HttpContext.Current != null)
      {
        var request = HttpContext.Current.Request;
        int id = request.QueryString["id"];
      }
    }
