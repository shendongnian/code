    private void Answer_Checked(object sender, RoutedEventArgs e) // Radio button click
        {
            var radio = sender as RadioButton;
            bool check = Convert.ToBoolean(radio.IsChecked);
            if(check)
            {
                Answer[Convert.ToInt16(radio.GroupName)] = Convert.ToInt16(radio.Tag);
            }
        }
        public async void Check_Result() // Evaluate result
        {
            foreach (KeyValuePair<int, int> count in Answer)
            {
                if (count.Value == 1)
                {
                    result++;
                }
            }
            MessageDialog showresult = new MessageDialog(result.ToString());
            await showresult.ShowAsync();
            Frame.Navigate(typeof(MainPage), null);
        }
       
        public void TestSubmit_Click(object sender, RoutedEventArgs e) // AppBar button click
        {
            Check_Result();
        }
