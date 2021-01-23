            private async void searchButton_Click(object sender, RoutedEventArgs e)
        {
            var textFrom = odTextBox.Text;
            var textTo = doTextBox.Text;
            var searchResult = await PrevoziApi.SearchRidesAsync(textFrom, textTo, datePicker.Date.UtcDateTime);
            List<CarItemView> array = searchResult.CarshareList
                                      .OrderBy(cs => cs.Time)
                                      .Select(cs => new CarItemView { DisplayText = cs.Contact + " " + cs.Time, Id = cs.Id })
                                      .ToList();
            listView.ItemsSource = array;
        }
            private void listView_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var obj = (CarItemView)listView.SelectedItem; // convert item to our new class
            Frame.Navigate(typeof(CarShareDetailedPage), obj.Id); // send ID as string        
        }
