     <DataGridTextColumn  Width="70" Header="Costo">
                    <DataGridTextColumn.Binding>
                        <MultiBinding Converter="{StaticResource ConcatConverter}">
                            <Binding Path="Costo" />
                            <Binding Path="SOSMoneda.Descripcion" />
                        </MultiBinding>
                    </DataGridTextColumn.Binding>
                </DataGridTextColumn>
  
     public class ConcatConverter : IMultiValueConverter
            {
                public object Convert(object[] values, Type targetType, object parameters, CultureInfo culture)
                {
                    return values[0].ToString() + " " + values[1].ToString();
                }
    
    
    
                public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
                {
                    throw new NotImplementedException();
                }
            }
