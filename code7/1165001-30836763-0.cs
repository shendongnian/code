    private void cboMouseUp(object sender, MouseButtonEventArgs e)
            {
                var textBox = (cbo.Template.FindName("PART_EditableTextBox", cbo) as TextBox);
                if (textBox != null && !cbo.IsDropDownOpen)
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(()=>{
                        textBox.SelectAll();
                        textBox.Focus();
                        //e.Handled = true;
                    }));
                }
