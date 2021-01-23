        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Executed from sub");
            var rc = e.Command as RoutedCommand;
            var parentInput = FindParentInput();
            if (parentInput != null && rc != null)
            {
                rc.Execute(null, parentInput);
            }
        }
        private IInputElement FindParentInput()
        {
            DependencyObject element = this;
            while (element != null)
            {
                DependencyObject parent = VisualTreeHelper.GetParent(element);
                var input = parent as IInputElement;
                if (input != null)
                    return input;
                element = parent;
            }
            return null;
        }
