    public class HomeView: MasterDetailPage
    {
        public   HomeView()
        {
            Label header = new Label
            {    
                Text = "MENU",
                Font = Font.BoldSystemFontOfSize(20),
                HorizontalOptions = LayoutOptions.Center
            };
            Label header1 = new Label
            {
                Text = "MENU1",
                Font = Font.BoldSystemFontOfSize(20),
                HorizontalOptions = LayoutOptions.Center
            };
            // create an array of the Page names
            string[] myPageNames = { "Main", "Page 2", "Page 3"};
            // Create ListView for the Master page.
            ListView listView = new ListView
            {
                ItemsSource = myPageNames,
            };
            ListView listView1 = new ListView
            {
                ItemsSource = myPageNames,
            };
            this.Master = new ContentPage
            {
                Content = new StackLayout
                {
                    Children = 
                    {
                        header, 
                        listView
                    }
                    }
            };
            // Set up the Detail, i.e the Home or Main page.
            Label myHomeHeader = new Label
            {
                Text = "Home Page",
                HorizontalOptions = LayoutOptions.Center
            };
            string[] homePageItems = { "Alpha", "Beta", "Gamma" };
            ListView myHomeView = new ListView 
            {
                ItemsSource = homePageItems,
            };
            this.Detail = new NavigationPage(new ContentPage
            {
                Content = new StackLayout
                {
                    Children = 
                    {
                        header1, 
                        myHomeView
                    },
                }
            });
        }
    }
