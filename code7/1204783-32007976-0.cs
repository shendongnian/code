    {
    
    /// <summary>
        /// Provides functionality to allow users to type only letters [0-9 A-F a-f]. 
        /// </summary>
        public class HexEditTextBox : TriggerAction<DependencyObject>
        {
            protected override void Invoke(object parameter)
            {
                var textBox = this.AssociatedObject as TextBox;
                if (textBox != null) textBox.PreviewKeyDown += HandlePreviewKeyDownEvent;
            }
    
            /// <summary>
            /// Checks whether the input is a valid key for a Hex number.
            /// Sets the 'Handled' Property as True if the input is invalid, so that further actions will not be performed for this Action.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e">KeyEventArgs instance</param>
            private void HandlePreviewKeyDownEvent(object sender, KeyEventArgs e)
            {
                var acceptedKeys = new List<Key>()
                                             {
                                                 Key.D0, Key.D1, Key.D2, Key.D3,Key.D4,Key.D5,Key.D6,Key.D7,Key.D8,Key.D9,
                                                 Key.A,Key.B,Key.C,Key.D,Key.E,Key.F,
                                                 Key.Tab,Key.Back,Key.Delete,Key.Left,Key.Right,Key.Up,Key.Down,Key.Enter,Key.Home,Key.End,
                                                 Key.NumPad0,Key.NumPad1,Key.NumPad2,Key.NumPad3,Key.NumPad4,Key.NumPad5,Key.NumPad6,Key.NumPad7,Key.NumPad8,Key.NumPad9
                                             };
    
                e.Handled = !acceptedKeys.Contains(e.Key);
            }
        }
    
    }
