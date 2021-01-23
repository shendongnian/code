    public class MessageStatusToColorDrawableConverter : MvxValueConverter<bool, ColorDrawable>
        {
            protected override ColorDrawable Convert(bool value, Type targetType, object parameter, CultureInfo cultureInfo)
            {
                var context = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity; // To get the context of the activity
    
                return value ? new ColorDrawable(new Color(ContextCompat.GetColor(context, Resource.Color.Pink))) : new ColorDrawable(new Color(ContextCompat.GetColor(context, Resource.Color.Green)));
            }
        }
