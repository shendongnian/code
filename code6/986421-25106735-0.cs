        private void Slider_OnValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (TextBox != null)
            {
                TextBox.Width = e.NewValue;
            }
        }
