    [TargetElement("MyControl", Attributes="page-info")]
    public class MyControlTagHelper : TagHelper {
      [HtmlAttributeName("page-info")]
      public Page page{ get;set; }
     //Here i have process methods.
     }
