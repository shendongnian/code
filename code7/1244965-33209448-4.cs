    using System;
    using System.Collections.Generic;
    
    using Xamarin.Forms;
    
    namespace LoginFormExample
    {
        public partial class LoginViewPage : ContentPage
        {
            public LoginViewPage ()
            {
                InitializeComponent ();
                BindingContext = new LoginViewModel();
            }
        }
    }
