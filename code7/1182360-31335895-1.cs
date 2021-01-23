    public class TicketPayoutModel 
    {
        public TicketPayoutModel(string logo)
        {
            this.Logo = logo;
        }
        public string Logo { get; set; }     
    }
    public ActionResult PayOutConfirmation()
    {
        return View(new TicketPayOutModel("logo.png"));
    }
