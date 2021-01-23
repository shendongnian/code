     public class ModulesMenuControl : Control
        {          
     static ModulesMenuControl()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(ModulesMenuControl), new FrameworkPropertyMetadata(typeof(ModulesMenuControl)));
            }
    
            public ModulesMenuControl()
            {
                this.Loaded += MouseCaptureControl_Loaded;
            }
    
            void MouseCaptureControl_Loaded(object sender, RoutedEventArgs e)
            {
                //throw new NotImplementedException();
                this.AddHandler(Mouse.PreviewMouseDownOutsideCapturedElementEvent, new MouseButtonEventHandler(onmousedown), true);
                Mouse.Capture(this, CaptureMode.SubTree);
            }
    
            private void onmousedown(object sender, MouseButtonEventArgs e)
            {
                MessageBox.Show("out click");
            }
