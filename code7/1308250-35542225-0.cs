    private void cmb_Loaded(object sender, RoutedEventArgs e)
        {
            TextBox TxtBox = (TextBox)cmb.Template.FindName("PART_EditableTextBox", cmb);
            if (TxtBox != null)
            {
                TxtBox.SelectionChanged += TxtBox_SelectionChanged;
            }
        }
        void TxtBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var TxtBox = sender as TextBox;
            if (TxtBox != null && !string.IsNullOrEmpty(TxtBox.SelectedText))
            {
                Mouse.OverrideCursor = Cursors.Cross;
            }
            else
            {
                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }
