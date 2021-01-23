        public async void MyFrameGoBackTest()
        {
            MyFrame.Navigate(typeof(SomePage));
            await Task.Delay(5000);//5 sec
            MyFrame.Navigate(typeof(SomePage));
            await Task.Delay(5000);//5 sec
            //add a breakpoint and check the CanGoBack
            if (MyFrame.CanGoBack)
            {
                MyFrame.GoBack();
            }
        }
