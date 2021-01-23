    public static readonly DependencyProperty ControllerProperty = DependencyProperty.Register(
            "Controller", typeof (StepController), typeof (Step), new PropertyMetadata(default(StepController)));
        public StepController Controller
        {
            get { return (StepController) GetValue(ControllerProperty); }
            set { SetValue(ControllerProperty, value); }
        }
