    using System;
    using Xamarin.Forms;
    
    namespace ContactManagerApp.Views
    {
        public partial class MainPage : ContentPage
        {
            public MainPage()
            {
                InitializeComponent();
            }
    
            
    
            private async void Btn_Clicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new NewContactPage()); 
            }
        }
    }
