    <Window x:Class="SOTextBoxForeground.MainWindow"
			xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
			xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
			xmlns:local="clr-namespace:SOTextBoxForeground"
			Title="MainWindow" Height="350" Width="525" Name="MyWindow">
		  <Window.Resources>
		  <local:ColorToSolidColorBrushConverter x:Key="ColorToSolidColorBrushConverter" />
	   </Window.Resources>
	   <Grid>
		  <Grid.Resources>
			 <Style x:Key="TextBoxStyle1" BasedOn="{StaticResource {x:Type TextBox}}" TargetType="{x:Type TextBox}">
				<Setter Property="Foreground" Value="{Binding ElementName=MyWindow, Path=pvColor, Converter={StaticResource ColorToSolidColorBrushConverter}}"/>
			 </Style>
		  </Grid.Resources>
		  <TextBox HorizontalAlignment="Left" Height="23" Margin="10,10,0,0" TextWrapping="Wrap" Text="TextBox" VerticalAlignment="Top" Width="120" Style="{StaticResource TextBoxStyle1}" />
		  <Button Content="Button" HorizontalAlignment="Left" Margin="433,10,0,0" VerticalAlignment="Top" Width="75" Click="Button_Click"/>
	   </Grid>
	</Window>
    public class ColorToSolidColorBrushConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         Color? desiredColor = value as Color?;
         if (desiredColor != null)
         {
            return new SolidColorBrush(desiredColor.Value);
         }
         //Return here your default
         return DependencyProperty.UnsetValue;
      }
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         return DependencyProperty.UnsetValue;
      }
    }
	public partial class MainWindow : Window
	{
		public static readonly DependencyProperty pvColorProperty = DependencyProperty.Register("pvColor",
		typeof(Color?), typeof(MainWindow),
		new PropertyMetadata(Colors.Red));
		public Color? pvColor
		{
			get { return (Color?)GetValue(pvColorProperty); }
			set { SetValue(pvColorProperty, value); }
		}
		public MainWindow()
		{
			InitializeComponent();
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.pvColor = Colors.Blue;
		}
	}
	public class ColorToSolidColorBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Color? desiredColor = value as Color?;
			if (desiredColor != null)
			{
				return new SolidColorBrush(desiredColor.Value);
			}
			//Return here your default
			return DependencyProperty.UnsetValue;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
