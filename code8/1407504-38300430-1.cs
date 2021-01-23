        private void OnGripperDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            DataGridColumnHeader header = this.HeaderToResize(sender);
            if ((header != null) && (header.Column != null))
            {
                header.Column.Width = DataGridLength.Auto;
                e.Handled = true;
            }
        }
