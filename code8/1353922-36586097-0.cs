        public class HelloLabelConverter : IValueConverter
        {
                public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
    		            char[] removeThis = "Hello ".ToCharArray();
                        return value.ToString().TrimStart(removeThis);
                }
    
                public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                        return string.Format("Hello {0}", value);
                }
        }
    
       <Window.Resources>
                <local:HelloLabelConverter x:Key="HelloLabelConverter" />
       </Window.Resources>
       <Grid>
           <Label Content="{Binding ElementName= lblPropertyToBind, Path=Text, Converter={StaticResource HelloLabelConverter}}"></Label>
       </Grid>
