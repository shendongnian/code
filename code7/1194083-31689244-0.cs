    void YourFunction(TypeOfResourceHome Resources)
    		{
    			Localization localization = new Localization();
    			FrameworkModel model = new FrameworkModel();
    			model.Page = new PageModel();
    			model.Page.Scripts = new PageModel.PageScripts();
    			//    .....
    			model.Page.Title = localization.LocalizeText(Resources.Home.Title);
    			model.Page.Keywords = localization.LocalizeText(Resources.Home.Keywords);
    			//     .....
    			model.Page.Body = localization.LocalizeText(Resources.Home.Body);
    			//       ....
    		}
        
   
