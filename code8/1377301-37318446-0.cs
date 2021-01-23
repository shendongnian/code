                    gadgetBase.Show();
                    var thisScreen = Screen.FromControl(this);
                    if (this.Location.Y < thisScreen.Bounds.Height/2)
                    {
                        //  we're in the top half
                        gadgetBase.Top = this.Bottom + SystemInformation.BorderSize.Height;
                        gadgetBase.Left = this.Left;
                    }
                    else
                    {
                        //  we're in the bottom half
                        gadgetBase.Top = this.Top - SystemInformation.BorderSize.Height - gadgetBase.Height;
                        gadgetBase.Left = this.Left;
                    }
