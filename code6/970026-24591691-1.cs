    //TODO: Bind grid to visibility property
                if (gridDisplay.Visibility == System.Windows.Visibility.Collapsed)
                {
                    var storyboard = this.Resources["open"] as Storyboard;
                    storyboard.Begin();
                    (sender as Button).Content = "<";
                }
                else
                {
                    var storyboard = this.Resources["close"] as Storyboard;
                    storyboard.Begin();
                    (sender as Button).Content = ">";
                }
