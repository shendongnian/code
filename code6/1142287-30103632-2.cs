        void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        delegate void test();
        public void Display()
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.BeginInvoke(new test(Display));
                return;
            }
            this.Show();
        }
