    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Willbe.Extensions;
    namespace Kiolyn.Wpf
    {
      public static class TouchAssist
      {
        public static bool GetTouchAsClick(DependencyObject obj)
          => (bool)obj.GetValue(TouchAsClickProperty);
        public static void SetTouchAsClick(DependencyObject obj, bool value)
          => obj.SetValue(TouchAsClickProperty, value);
        // Using a DependencyProperty as the backing store for SelectOnMouseOver.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TouchAsClickProperty =
            DependencyProperty.RegisterAttached(
              "TouchAsClick",
              typeof(bool),
              typeof(TouchAssist),
              new UIPropertyMetadata(false, OnTouchAsClickChanged));
        // Using a DependencyProperty as the backing store for SelectOnMouseOver.  This enables animation, styling, binding, etc...
        private static readonly DependencyProperty LastExecuteTimeProperty =
            DependencyProperty.RegisterAttached(
              "LastExecuteTime",
              typeof(DateTime),
              typeof(TouchAssist),
              new UIPropertyMetadata(null));
        private static readonly DependencyProperty TouchDownPositionProperty =
            DependencyProperty.RegisterAttached(
              "TouchDownPosition",
              typeof(Point),
              typeof(TouchAssist),
              new UIPropertyMetadata(null));
        static void OnTouchAsClickChanged(DependencyObject d, DependencyPropertyChangedEventArgs ev)
        {
          if (d is Button button)
          {
            button.IsManipulationEnabled = true;
            button.TouchDown += (s, e) =>
            {
              button.RaiseEvent(new MouseButtonEventArgs(Mouse.PrimaryDevice, e.Timestamp, MouseButton.Left)
              {
                RoutedEvent = Mouse.PreviewMouseDownEvent
              });
              button.ClearValue(LastExecuteTimeProperty);
              button.SetValue(TouchDownPositionProperty, e.GetTouchPoint(Application.Current.MainWindow).Position);
            };
            button.TouchUp += (s, e) =>
            {
              var command = button.Command;
              var parameter = button.CommandParameter;
              if (command != null && command.CanExecute(parameter) && button.GetValue(TouchDownPositionProperty) is Point touchDownPosition)
              {
                var touchUpPosition = e.GetTouchPoint(Application.Current.MainWindow).Position;
                var dx = Math.Abs(touchUpPosition.X - touchDownPosition.X);
                var dy = Math.Abs(touchUpPosition.Y - touchDownPosition.Y);
                if (dx < 32 && dy < 32)
                {
                  // Should be treated as click
                  // Mark the last execute time
                  button.SetValue(LastExecuteTimeProperty, DateTime.Now);
                  command.Execute(parameter);
                }
              }
            };
            button.PreviewMouseLeftButtonUp += (s, e) =>
            {
              if (button.GetValue(LastExecuteTimeProperty) is DateTime lastExecuteTime && DateTime.Now.Subtract(lastExecuteTime).Milliseconds < 300)
              {
                e.Handled = true;
                button.ReleaseMouseCapture();
              }
              button.ClearValue(LastExecuteTimeProperty);
            };
          }
        }
      }
    }
