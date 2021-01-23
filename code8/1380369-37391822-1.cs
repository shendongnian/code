    <script type="text/javascript">
    function Test() {
        PageMethods.Test(function(result){alert(result);});
    }
    [System.Web.Services.WebMethod]
    public static string Test()
    {
      return "Hello StackOverflow";
    }
