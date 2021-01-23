    public partial class LoginViewController : UIViewController
    {
        private UIScrollView scrollView;
        private UITextField txt_username, txt_password;
        private UIButton btn_login;
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
     
            /*Depending on what else is on the screen, you can hard-code the 
            x, y, width and height, but in all other cases, use this:*/
            scrollView = new UIScrollView (this.View.Bounds);
            txt_username = new UITextField (new RectangleF (5, 5, 50, 25));
            //Change other properties of the UITextfield to your liking here.
            txt_password = new UITextField (new RectangleF (5, 35, 50, 25));
            //Change other properties of the UITextfield to your liking here.
            btn_login = new UIButton (new RectangleF (5, 65, 50, 25));
            btn_login.TouchUpInside += Login;
            //Change other properties of the UIButton to your liking here.
            this.View.AddSubview (scrollView);
            scrollView.AddSubviews (new UIView[]{txt_username, txt_password, btn_login});
        }
        void Login (object sender, eventargs e)
        {
            //Do something on button click
        }
    }
