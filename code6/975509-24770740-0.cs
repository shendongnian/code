    <Window x:Class="WpfApplication13.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:local ="clr-namespace:WpfApplication13"
            Title="MainWindow" Height="350" Width="525">
        <Window.Resources>
            <local:converter x:Key="pointConverter" />
        </Window.Resources>
        <Grid x:Name="control" >
            <Polygon Fill="Black" Stroke="Black">
                <Polygon.Points>
                    <MultiBinding  Converter="{StaticResource pointConverter}" >
                        <Binding Path="ActualWidth"  ElementName="control"/>
                        <Binding Path="ActualHeight"  ElementName="control"/>
                    </MultiBinding>
                </Polygon.Points>
            </Polygon>
        </Grid>
    </Window>
 
    class converter : IMultiValueConverter
        {
         
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                try
                {
                    double width = (double)values[0];
                    double height = (double)values[1];
    
                    PointCollection pc = new PointCollection();
                    pc.Add(new Point(0, 0));
                    pc.Add(new Point(width - 10, height - 10));
                    return pc;
                }
                catch
                {
                    return null;
                }
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
