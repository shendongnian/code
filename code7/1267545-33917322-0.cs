    private void myTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (e.Source is TabControl) //if this event fired from TabControl
                {
                    if (tabItemName.IsSelected)
                    {
                        //Do what you need here.
                    }
                }
            }
