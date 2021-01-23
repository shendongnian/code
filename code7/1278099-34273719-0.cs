    public class IsFavoriteBehavior
    {
        public static bool GetIsFavorite(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsFavoriteProperty);
        }
        public static void SetIsFavorite(DependencyObject obj, bool value)
        {
            obj.SetValue(IsFavoriteProperty, value);
        }
        public static readonly DependencyProperty IsFavoriteProperty =
            DependencyProperty.RegisterAttached("IsFavorite", typeof(bool), typeof(Button), new PropertyMetadata(false, (o, e) =>
            {
                var button = o as Button;
                if (button == null)
                    return;
                if ((bool)e.NewValue)
                {
                    button.Background = (SolidColorBrush)Application.Current.Resources["HighlightBackgroundColorBrush"];
                    button.Foreground = (SolidColorBrush)Application.Current.Resources["HighlightTextColorBrush"];
                }
                else
                {
                    button.Background = (SolidColorBrush)Application.Current.Resources["NormalBackgroundColorBrush"];
                    button.Foreground = (SolidColorBrush)Application.Current.Resources["NormalTextColorBrush"];
                }
                o.SetValue(IsFavoriteProperty, e.NewValue);
            }));
    }
