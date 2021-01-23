        private void stackPanel_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == inputTextBox) // Change the inputTextBox to your TextBox name
                {
                    FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
                    FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
                }
                else
                { 
                    FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
                }
                // Make sure to set the Handled to true, otherwise the RoutedEvent might fire twice
                e.Handled = true;
            }
        }
