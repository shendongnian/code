        private void SearchButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Text = "Search Button Clicked!";
            // Now it is working! :)
        }
        private void artistNameEditText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Toast.MakeText(this, "Text has just changed!", ToastLength.Long).Show();
            // Now it is working! :)
        }
  
