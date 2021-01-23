        public partial class MyView : UserControl
        {
            public MyView()
            {
                InitializeComponent();
                this.KeyDown += new KeyEventHandler(KeyDownEvent);
            }
            private void KeyDownEvent(object sender, KeyEventArgs e)
            {
                try
                {
                    switch (e.Key)
                    {
                        case Key.F2:
                            var vm = this.DataContext as YourViewModel;
                            vm.YourCommand.Execute(null);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    //...
                }
            }
        }
