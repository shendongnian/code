        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                dgRoot.Children.Clear();
                UserControl control = null;
                if (<your_condition>)
                {
                    control = new UserControl1();
                }
                else
                {
                    control = new UserControl2();
                }
                control.SetValue(Grid.ColumnProperty, 2);
                this.dgRoot.Children.Add(control);
        }
