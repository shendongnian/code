    using System;
    using System.Windows;
    using System.Windows.Controls;
    namespace WpfApplication1.Controls
    {
        [TemplatePart(Name = "PART_ResetButton", Type = typeof(Button))]
        public class ComboBoxReset : ComboBox
        {
            private Button _resetButton;
            // reset event (not used in this demo case, but should be provided)
            public static readonly RoutedEvent ResetEvent = EventManager.RegisterRoutedEvent("Reset", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComboBoxReset));
            public event RoutedEventHandler Reset { add { AddHandler(ResetEvent, value); } remove { RemoveHandler(ResetEvent, value); } }
            private void OnReset()
            {
                RoutedEventArgs args = new RoutedEventArgs(ResetEvent);
                RaiseEvent(args);
            }
            public ComboBoxReset()
            {
                // lookless control, get default style from generic.xaml
                DefaultStyleKeyProperty.OverrideMetadata(typeof(ComboBoxReset), new FrameworkPropertyMetadata(typeof(ComboBoxReset)));
            }
            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
                if (this.Template != null)
                {
                    // find reset button in template
                    Button btn = this.Template.FindName("PART_ResetButton", this) as Button;
                    if (_resetButton != btn)
                    {
                        // detach old handler
                        if (_resetButton != null)
                            _resetButton.Click -= ResetButton_Click;
                        _resetButton = btn;
                    
                        // attach new handler
                        if (_resetButton != null)
                            _resetButton.Click += ResetButton_Click;
                    }
                }
            }
            private void ResetButton_Click(object sender, RoutedEventArgs e)
            {
                // reset the selected item and raise the event
                this.SelectedItem = null;
                OnReset();
            }
        }
    }
