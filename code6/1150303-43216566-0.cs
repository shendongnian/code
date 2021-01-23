     UIAlertView Msg = new UIAlertView()
                        {
                            Title = "Title",
                            Message = "Content" 
                        };
                        UIImageView uiIV = new UIImageView(UIImage.FromFile("ImgFile.Png"));
                        Msg.SetValueForKey(uiIV, (NSString)"accessoryView");
                        Msg.AddButton("OK");
                        Msg.Show();
