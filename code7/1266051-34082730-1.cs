     /// <summary>
        /// Converter for simple math operations. It should be bound to a source path, which has a number for its value.
        /// the parameter should be a string with a format of "N|xxxxx" (without quotes), where N is a number, the '|'
        /// sign is a separator and the second parameter (xxxxx) is a string defining the operation. Valid values are
        /// add, subtract, multiply and divide. Below example shows how a button's width is set to one third of the
        /// parent's canvas width:
        /// <Canvas x:Name="mainCanvas" Height="220" Width="260">
        ///     <Button x:Name="button1" 
        ///                Content="Button" 
        ///                Height="30" 
        ///                Canvas.Left="0" Canvas.Top="79" 
        ///                Width="{Binding ElementName=mainCanvas, Path=Width, 
        ///                                Converter={local:ScreenRatioConverter}, 
        ///                                ConverterParameter='3|divide'}"/>
        /// </Canvas>
        /// </summary>
        [ValueConversion(typeof(string), typeof(string))]
        public class ScreenRatioConverter : MarkupExtension, IValueConverter
        {
            private static ScreenRatioConverter _instance;
            
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                string parameterString = parameter as string;
                string[] parameters = parameterString.Split(new char[] { '|' });
                double par1 = System.Convert.ToDouble(value);
                double par2 = System.Convert.ToDouble(parameters[0], CultureInfo.InvariantCulture);
                string operation = (string)parameters[1];
                double result = 20; //Default value to return if anything goes wrong.
                if (operation.Equals("add"))
                { result = par1 + par2; }
                else if (operation.Equals("subtract"))
                { result = par1 - par2; }
                else if (operation.Equals("multiply"))
                { result = par1 * par2; }
                else if (operation.Equals("divide"))
                { result = par1 / par2; }
    
                return result;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            //Needs to be overridden because of inheritance from MarkupExtension.
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                return _instance ?? (_instance = new ScreenRatioConverter());
            }
    
        }
    
    }
