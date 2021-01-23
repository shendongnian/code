      partial class HarachieRolliController : UIViewController
      {
        public HarachieRolliController (IntPtr handle) : base (handle)
        {
        }
        public async override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
            string url2 = "http://papajohn.pp.ua/?mkapi=getProductsByCat&cat_id=83";
            JsonValue json = await FetchAsync(url2);
            ParseAndDisplay (json);
        }
        private async void ParseAndDisplay(JsonValue json)
        {
            String title = json[1]["post_title"].ToString();
            button_arrow_product002.TouchUpInside += delegate {
                Console.Out.WriteLine ("Clicked Button (button_arrow_product002)");
                // Use a segue to display the DetailTovarProsmotr
                this.PerformSegue('YOUR SEGUE ID', this);
                // The segue needs to be defined in the storyboard with a unique id
            };
        }
        protected override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender) {
            var detailTovarPostr = segue.DestinationViewController as DetailTovarPostr;
            // Initialized your custom view controller however you like
           // Consider defining properties or an initialize method and pass in the title and other data
           // TODO pass data :)
        }
    }
    
