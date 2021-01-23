    public static class DisposableExtensions
    {
      public static IDisposable DisposableDiv(this HtmlHelper htmlHelper)
       {
         return new DisposableHelper(
            () => htmlHelper.BeginDiv(),
            () => htmlHelper.EndDiv());
       }
	
	  public static void BeginDiv(this HtmlHelper htmlHelper)
	   {
		 htmlHelper.ViewContext.Writer.Write("<div>");
       }
		
	
	  public static void EndDiv(this HtmlHelper htmlHelper)
	   {
		 htmlHelper.ViewContext.Writer.Write("</div>");
	   }
      }
    }
