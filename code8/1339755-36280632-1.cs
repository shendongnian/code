    public class MainPage : MasterDetailPage
        {
            public MainPage()
            {
                MasterPage masterPage;
                masterPage = new MasterPage();
                Master = masterPage;
                Detail = new NavigationPage(new TestPage())
                {
                    //Tint = Color.Red // put your color here
                    BarBackgroundColor = Color.FromRgb(172, 183, 193),//Color.FromHex("#9E9E9E"),
                    BarTextColor = Color.Black,
                    BackgroundColor = Color.White
                };
            }
            protected override void OnAppearing()
            {
                MessagingCenter.Subscribe<Class1.OpenMyPageMessage>(this, Class1.OpenMyPageMessage.Key, (sender) =>
                {
                    Detail = new Page1 { Padding = Device.OnPlatform(50, 100, 100) };
                });
                MessagingCenter.Subscribe<Class1.OpenPage2>(this, Class1.OpenPage2.Key, (sender) =>
                {
                    Detail = new Page2();
                });
            }
    
            protected override void OnDisappearing()
            {
                MessagingCenter.Unsubscribe<Class1.OpenMyPageMessage>(this, Class1.OpenMyPageMessage.Key);
                MessagingCenter.Unsubscribe<Class1.OpenPage2>(this, Class1.OpenPage2.Key);
            }
         }
