        [TestMethod]
        public void TestSizeChanged()
        {
            Window wnd = new Window();
            wnd.Content = new System.Windows.Controls.StackPanel();
            bool handled = false;
            wnd.SizeChanged += (o, e) =>
            {
                handled = true; // how to get this to be executed
            };
            wnd.Show();
            wnd.Width = 100; // naive attempt to change size!
            Assert.IsTrue(handled);
        }
