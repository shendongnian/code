 c#
public class Message : IMessage
{
    private const double LONG_DELAY = 3.5;
    private const double SHORT_DELAY = 2.0;
    public void LongAlert(string message) =>
    ShowMessage(message, LONG_DELAY);
    public void ShortAlert(string message) =>
    ShowMessage(message, SHORT_DELAY);
    private void ShowMessage(string message, double duration)
    {
        var label = new TextBlock
        {
            Text = message,
            Foreground = new SolidColorBrush(Windows.UI.Colors.White),
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
        };
        var style = new Style { TargetType = typeof(FlyoutPresenter) };
        style.Setters.Add(
            new Setter(
                Control.BackgroundProperty,
                new SolidColorBrush(Windows.UI.Colors.Black)));
        style.Setters.Add(new Setter(FrameworkElement.MaxHeightProperty, 1));
        
        var flyout = new Flyout
        {
            Content = label,
            Placement = FlyoutPlacementMode.Full,
            FlyoutPresenterStyle = style,
        };
        flyout.ShowAt(Window.Current.Content as FrameworkElement);
        var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(duration) };
        timer.Tick += (sender, e) => {
            timer.Stop();
            flyout.Hide();
        };
        timer.Start();
    }
}
Coloring and styling is up to you, the `MaxHeight`is actually required to keep the height at the minimum.
