        private void Button_Click(object sender, RoutedEventArgs e) {
            SecondForm form = new SecondForm();
            form.Closing += form_Closing;
            form.Show();
        }
        void form_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            llMsg.Content = "The second form is closing";
        }
