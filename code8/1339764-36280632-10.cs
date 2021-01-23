    public class TestPage : ContentPage
        {
            public TestPage()
            {
                Button test = new Button();
                test.Clicked += test_Clicked;
                test.Text = "Save";
                Button test1 = new Button();
                test1.Clicked += test1_Clicked;
                test1.Text = "cancel";
                Content = new StackLayout
                {
                    Children = {
                        test,
                        test1
                    }
                };
            }
    
            void test_Clicked(object sender, EventArgs e)
            {
                 MessagingCenter.Send(new Class1.OpenPage2(), Class1.OpenPage2.Key);
            }
            void test1_Clicked(object sender, EventArgs e)
            {
                
            }
        }
