        int lastIndex = 0;
    private async void PageChanged(object sender, SelectionChangedEventArgs e)
            {
                switch (MainPivot.SelectedIndex)
                {
                    case 0:
                        //Do smth
                        break;
                    case 1:
                        //Do smth
                        break;
                    case 2:
                        //Do smth
                        break;
                    case 3:
                        //Do smth
                        break;
                }
                if (MainPivot.SelectedIndex + 1 == lastIndex)
                {
                    await Task.Delay(50);
                    MainPivot.SelectedIndex = 0;
                }
                lastIndex = MainPivot.SelectedIndex;
            }
