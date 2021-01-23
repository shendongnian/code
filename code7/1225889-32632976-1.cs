        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            k = txbTarget1.Text;
            KeyConverter x = new KeyConverter();
            Key kinput = (Key)x.ConvertFromString(k);
            if (e.Key == kinput)
            {
                Storyboard h1 = this.FindResource("t1_Hit") as Storyboard;
                h1.Begin();
            }
        }
