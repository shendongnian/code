     double width = Convert.ToDouble(HtmlPage.Window.Eval("screen.width"));
                    double height = Convert.ToDouble(HtmlPage.Window.Eval("screen.height"));
    
                    AdvertisingControl ac = new AdvertisingControl(); // Your user control here..
    
                    this.p = new Popup()
                    {
                        VerticalOffset = (height - ac.Height) / 2.0,
                        HorizontalOffset = (width - ac.Width) / 2.0,
                        Width = ac.Width,
                        Height = ac.Height,
                        Child = ac,
                    };
    
                    this.p.IsOpen = true;
