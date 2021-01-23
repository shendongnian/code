    void Main()
    {
        // Need to parse XAML since LinqPad doesn't have an integrated XAML build
        var xaml = @"
        <Grid xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
        <Grid.Resources>
        <Style TargetType=""Control"" x:Key=""imageTextBox"">
            <Setter Property=""Margin"" Value=""0,0,0,8""/>
            <Setter Property=""Template"">
                <Setter.Value>
                    <ControlTemplate TargetType=""Control"">
                        <Border x:Name=""bg"" BorderThickness=""1"" CornerRadius=""3"" BorderBrush=""Gray"">
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width=""30""/>
                                    <ColumnDefinition Width=""*""/>
                                </Grid.ColumnDefinitions>
                                <TextBox Style=""{DynamicResource BasicTextBox}"" Grid.Column=""1""
                                         Foreground=""{TemplateBinding Foreground}""
                                         Background=""{TemplateBinding Background}""
                                         FontFamily=""{TemplateBinding FontFamily}""
                                         FontSize=""{TemplateBinding FontSize}""
                                         FontWeight=""{TemplateBinding FontWeight}""
                                         MinWidth=""340"" Margin=""1"" />
                                <Image Source=""{Binding Image}"" Width=""20""/>
                            </Grid>
                        </Border>
    
                        <ControlTemplate.Triggers>
                            <Trigger Property=""IsMouseOver"" Value=""True"">
                                <Setter Property=""BorderBrush"" TargetName=""bg"" Value=""Black""/>
                            </Trigger>
                            <Trigger Property=""IsFocused"" Value=""True"">
                                <Setter Property=""BorderBrush"" TargetName=""bg"" Value=""Black""/>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        </Grid.Resources>
        <TextBox Style=""{StaticResource imageTextBox}"" />
        </Grid>
        ";
        // Get some images... these could be in your resources
        var png = PngBitmapDecoder.Create(new Uri("https://upload.wikimedia.org/wikipedia/commons/9/97/Esperanto_star.png"), BitmapCreateOptions.None, BitmapCacheOption.Default);
        var vm = new ViewModel { Image = png.Frames[0] };
        var o = (FrameworkElement)XamlReader.Parse(xaml);
        // Set the image source - in this case, a view model
        o.DataContext = vm;
        // Let LinqPad display it
        PanelManager.DisplayWpfElement(o);
        // This code is for the example only, to change the image after 2 seconds.
        var dispatcher = o.Dispatcher;
        Task.Run(async () =>
        {
            await Task.Delay(2000);
            await dispatcher.BeginInvoke((Action)(() =>
            {
                png = PngBitmapDecoder.Create(new Uri("https://upload.wikimedia.org/wikipedia/commons/f/f6/Lol_question_mark.png"), BitmapCreateOptions.None, BitmapCacheOption.Default);
                vm.Image = png.Frames[0];
            }));
        });
    }
    
    // Define other methods and classes here
    public class ViewModel : INotifyPropertyChanged
    {
        private ImageSource _image;
        public event PropertyChangedEventHandler PropertyChanged;
    
        public ImageSource Image
        {
            get
            {
                return _image;
            }
            set
            {
                if (_image == value)
                {
                    return;
                }
    
                _image = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Image)));
            }
        }
    }
