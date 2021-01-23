    namespace NameSpace.UserControl
    {
    	public partial class UserControlClass: UserControl
    	{
         ...........
        }
    
    	public class BoolInverter : MarkupExtension, IValueConverter
    	{
    		public override object ProvideValue(IServiceProvider serviceProvider)
    		{ return this; }
    		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    		{ return !(bool)value; }
    		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    		{ return !(bool)value; }
    	}
    }
