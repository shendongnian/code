public class ConditionalVisibilityConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object paramater, CultureInfo culture)
  {
    ViewModelType viewModelParent   = ((values[2] as FrameworkElement).DataContext) as ViewModelType;
    // Sneak in an update of viewmodelparent via physical parent.
    viewModelParent.HasVisibleChild = parentViewModel.EvaluateHasVisibleChild();
    return (bool)values[0] && (bool)values[1] ? Visibility.Visible : Visibility.Collapsed;
  }
  public object[] ConvertBack(object value, Type[] targetTypes, object paramweter, CultureInfo cultuer)
  {
    throw new NotImplementedException();
  }
}
