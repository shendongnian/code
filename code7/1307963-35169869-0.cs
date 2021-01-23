    private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            List<ValidObjectVerificationGrid> fullSource = (List<ValidObjectVerificationGrid>dgValidObjectVerification.ItemsSource;
            ValidObjectVerificationGrid x = null;
            int index ;
            try
            {
                x = (ValidObjectVerificationGrid)dgValidObjectVerification.SelectedItem;
                index = dgValidObjectVerification.SelectedIndex;
            }
            catch
            {
            }
            if (x!=null)
            {
                // ... Get RadioButton reference.
                var button = sender as RadioButton;
                // ... Display button content as title.
                this.Title = button.Content.ToString();
                if ((Boolean)button.IsChecked)
                {
                    x.ObjectType = (enumObjectType)Enum.Parse(typeof(enumObjectType), button.Content.ToString(), true);
                }
                foreach (ValidObjectVerificationGrid tmp in fullSource)
                {
                    if (tmp.Count == x.Count)
                        tmp.ObjectType = x.ObjectType;
                }
                dgValidObjectVerification.ItemsSource = null;
                dgValidObjectVerification.ItemsSource = fullSource;
                
            }
        }
