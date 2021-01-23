    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.img.Source = new BitmapImage(new Uri("https://www.google.com/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png"));
            this.Effect = new ColorComplementEffect();
        }
    }
    public class ColorComplementEffect : ShaderEffect
    {
        public ColorComplementEffect()
        {
            PixelShader = _shader;
            UpdateShaderValue(InputProperty);
        }
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ColorComplementEffect), 0);
        private static PixelShader _shader = new PixelShader() { UriSource = new Uri(@"cc.ps") };
    }
