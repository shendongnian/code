            Frame rootFrame = Window.Current.Content as Frame;
            e.Handled = true;
           
            var curpage = rootFrame.CurrentSourcePageType.FullName;
                if(curpage=="your page name where you want to show dialog")
                { 
                var msg = new MessageDialog("Sure to Exit?");
                var okBtn = new UICommand("OK");
                var cancelBtn = new UICommand("Cancel");
                msg.Commands.Add(okBtn);
                msg.Commands.Add(cancelBtn);
                IUICommand result = await msg.ShowAsync(); 
                if (result != null && result.Label == "OK")
                {
                    Application.Current.Exit();
                }
            }
                else
                {
                    if (rootFrame.CanGoBack)
                    {
                        rootFrame.GoBack();
                    }
                }
        }
