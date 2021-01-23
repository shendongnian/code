    public class DeviceViewModel
        {
            public string Name { get; set; }
    
            private DelegateCommand flyoutCommand;
            public ICommand FlyoutCommand
            {
                get
                {
                    if (flyoutCommand == null)
                    {
                        flyoutCommand = new DelegateCommand((parameter) => FlyoutLogic(), (parameter) => CanFlyout());
                    }
                    return flyoutCommand;
                }
            }
    
            private bool CanFlyout()
            {
                return true;
            }
    
            private void FlyoutLogic()
            {
                Debug.WriteLine("here we go");
            }
        }
