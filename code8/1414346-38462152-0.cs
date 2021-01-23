    class MyShaderEffect
    {
        public MyShaderEffect()
        {
            PixelShader = _pixelShader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(ThresholdProperty);
        }
        public double Threshold
        {
            get { return (double)GetValue(ThresholdProperty); }
            set { SetValue(ThresholdProperty, value); }
        }
        public static readonly DependencyProperty ThresholdProperty =
            DependencyProperty.Register("Threshold", typeof(double), typeof(MyShaderEffect),
                    new UIPropertyMetadata(0.5, PixelShaderConstantCallback(0)));
    }
