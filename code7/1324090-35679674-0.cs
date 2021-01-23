        public class MainViewModel
        {
            public ColorModel CM1 { get; set; }
            public ColorModel CM2 { get; set; }
    
            public GradientModel GM { get; set; }
    
            public MainViewModel()
            {
                CM1 = new ColorModel();
                CM2 = new ColorModel();
                GM = new GradientModel();
    
                Binding b1 = new Binding("Color");
                b1.Source = CM1;
                b1.Mode = BindingMode.OneWay;
                BindingOperations.SetBinding(GM, GradientModel.FirstProperty, b1);
    
                Binding b2 = new Binding("Color");
                b2.Source = CM2;
                b2.Mode = BindingMode.OneWay;
                BindingOperations.SetBinding(GM, GradientModel.LastProperty, b2);
            }
        }
        <TextBox x:Name="Ctrl1" HorizontalAlignment="Left" Height="23" Margin="32,48,0,0" TextWrapping="Wrap" Text="{Binding CM1.Color}" VerticalAlignment="Top" Width="120"/>
        <TextBox x:Name="Ctrl2" HorizontalAlignment="Left" Height="23" Margin="32,103,0,0" TextWrapping="Wrap" Text="{Binding CM2.Color}" VerticalAlignment="Top" Width="120"/>
