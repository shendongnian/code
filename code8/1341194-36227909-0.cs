    public static void RenderPartialWithPrefix(this HtmlHelper helper, string partialViewName, object model, string prefix)
    {
    	helper.RenderPartial(partialViewName,
    						 model,
    						 new ViewDataDictionary { 
    							TemplateInfo = new System.Web.Mvc.TemplateInfo { 
    								HtmlFieldPrefix = prefix 
    							} 
    						});
    }
