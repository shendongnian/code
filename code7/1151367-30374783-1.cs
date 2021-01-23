    <Image Grid.Column="0" Grid.Row="0" x:Name="img_selected" Source="{Binding IsSelected, Converter={StaticResource SelectedImageConverter}}" Width="26" Height="29"></Image>
    public class SelectedImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var isSelected = (bool)value;
                return isSelected
                    ? "/Assets/ic_selected.png"
                    : "/Assets/ic_not_selected.png";
            }
            catch (Exception)
            {
                return "/Assets/ic_not_selected.png";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
