     public class LayoutViewDataAttribute : ActionFilterAttribute
     {
         public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            IJourneyConstants constants;
             try{
               constants = (IJourneyConstants )System.Activator.CreateInstance(this.Provider);
             }catch (Exception e){
                 throw new Exception("Failed to create instance of IJourneyConstants from " + 
                     $"{this.Provider.Name}.  Ensure it inherits from IJourneyConstants "+ 
                      "and contains a public paramaterless constructor.");
             }
             // perform any common calculation using your constants
             bool isContactNumberInternational = constants.ContactNumber.StartsWith("+");
             // update the ViewData
             filterContext.Controller.ViewData.Add("ContactNumber", 
                 constants.ContactNumber);
             filterContext.Controller.ViewData.Add("IsNumberInternational", 
                 isContactNumberInternational);
       }    
    } 
