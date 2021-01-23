    public class PayNowViewModel {
        // SelectListItems are only generated if this gets rendered
        public Month ExpiryMonth { get; set; }
    }
    
    // Intial Action
    var paymentGateway = new PayNowViewModel();
    return View(paymentGateway);
    // Razor View: call the EditorTemplate 
    @Html.EditorFor(m => m.ExpiryMonth)
   
