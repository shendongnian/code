    <script type="text/javascript">
    function Test(Id) {
        PageMethods.Test(function(result){alert(result);});
    }
    [System.Web.Services.WebMethod]
    public static string Test()
    {
      return "Hello StackOverflow";
    }
