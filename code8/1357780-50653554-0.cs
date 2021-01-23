           switch(Device.RuntimePlatform)
            {
                case Device.iOS:
                    Padding = new Thickness(0, 20, 0, 0);
                    break;
                case Device.Android:
                    Padding = new Thickness(10, 20, 0, 0);
                    break;
                case Device.WinPhone:
                    Padding = new Thickness(30, 20, 0, 0);
                    break;
            }
