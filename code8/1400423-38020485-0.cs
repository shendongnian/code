    public class FilterPage : ContentPage
    {
        public FilterPage()
        {
            var restaurantTypes = new[] {"Pizza", "China", "German"};
            ListView types = new ListView();
            types.ItemTemplate = new DataTemplate(() =>
            {
                var cell = new SwitchCell();
                cell.SetBinding(SwitchCell.TextProperty, ".");
                return cell;
            });
            types.ItemsSource = restaurantTypes;
            Content = types;
        }
    }
