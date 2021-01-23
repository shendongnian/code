    private void DoSomethingAmazing(object sender, RoutedEventArgs e)
        {
            Grid grd = new Grid();
            TextBlock txt = new TextBlock()
            {
                Text = "Wow!"
            };
            grd.Children.Add(txt);
            //Add your grid to the window/page/usercontrol
            this.AddChild(grd);
        }
