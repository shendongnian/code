    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    using System.Windows.Interactivity;
    using System.Windows.Threading;
    
        public class KeyboardFocusBehavior : Behavior<Control>
        {
            public bool Focused
            {
                get { return (bool)GetValue(FocusedProperty); }
                set { SetValue(FocusedProperty, value); }
            }
            public static readonly DependencyProperty FocusedProperty = DependencyProperty.Register("Focused", 
                typeof(bool), 
                typeof(ControlKeyboardFocusBehavior), 
                new PropertyMetadata(false, OnFocusedPropertyChanged));
    
            private static void OnFocusedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                ControlKeyboardFocusBehavior b = d as ControlKeyboardFocusBehavior;
    
                if(b != null && b.AssociatedObject != null)
                {
                    Control c = b.AssociatedObject;
    
                    if (!c.IsFocused && (bool)e.NewValue)
                    {
                        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(delegate()
                        {
                            c.Focus();         
                            Keyboard.Focus(c);
                            TouchKeyboard.Show();
                        }));
                    }
                }
            }
    		
        public class ShowTouchKeyboardOnFocusBehavior : Behavior<Control>
        {
            protected override void OnAttached()
            {
                base.OnAttached();
                WeakEventManager<Control, KeyboardFocusChangedEventArgs>.AddHandler(AssociatedObject, "GotKeyboardFocus", OnGotKeyboardFocus);
                WeakEventManager<Control, KeyboardFocusChangedEventArgs>.AddHandler(AssociatedObject, "LostKeyboardFocus", OnLostKeyboardFocus);
            }
    
            private void OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
            {
                // show the touch keyboard
                TouchKeyboard.Show();
                var textBox = sender as TextBox;
                if (textBox != null)
                    textBox.SelectionStart = Math.Max(0, textBox.Text.Length);
            }
    
            private void OnLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
            {
                // hide the touch keyboard
                TouchKeyboard.Hide();
            }
        }
