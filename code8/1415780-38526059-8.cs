public class ConditionalVisibilityConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object paramater, CultureInfo culture)
  {
    // Has no ancestor safety check
    if (values[2] != DependencyProperty.UnsetValue)
      // Sneak in an update of viewmodelparent via physical parent.
      (((values[2] as FrameworkElement).DataContext) as ViewModelType).EvaluateHasVisibleChild();
    return (bool)values[0] && (bool)values[1] ? Visibility.Visible : Visibility.Collapsed;
  }
  public object[] ConvertBack(object value, Type[] targetTypes, object paramweter, CultureInfo cultuer)
  {
    throw new NotImplementedException();
  }
}
