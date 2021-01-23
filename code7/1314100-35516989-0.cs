            private void listViewContentChange(ListViewBase sender, ContainerContentChangingEventArgs args) {
                //this method is called for each item while it gets loaded in the listview. Here we are changing background color and text color
                if (args.ItemIndex == 0) {
                  //colour for header
                  args.ItemContainer.Background = (SolidColorBrush) Application.Current.Resources["grey"];
                } else {
                  if (args.ItemIndex % 2 == 0) {
                    //lighter colour 
                    args.ItemContainer.Background = (SolidColorBrush) Application.Current.Resources["lightblue"];
                  } else {
                    //Dark colour 
                    args.ItemContainer.Background = (SolidColorBrush) Application.Current.Resources["blue"];
                  }
                }
