    public static class DisposableExtensions
    {
      public static IDisposable DisposableTr(this HtmlHelper htmlHelper)
       {
         return new DisposableHelper(
            () => htmlHelper.BeginTr(),
            () => htmlHelper.EndTr());
       }
	
	  public static void BeginTr(this HtmlHelper htmlHelper)
	   {
		 htmlHelper.ViewContext.Writer.Write("<div>");
       }
		
	
	  public static void EndTr(this HtmlHelper htmlHelper)
	   {
		 htmlHelper.ViewContext.Writer.Write("</div>");
	   }
      }
    }
