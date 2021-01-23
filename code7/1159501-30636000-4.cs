        private void cmdCommand_Click(object sender, RoutedEventArgs e)
        {
             var person = this.DataContext as PersonViewModel;
             if(person == null) return;
             lblFullName.Content = string.Format("{0} {1}", person.FirstName, person.LastName);
        }
