    [assembly: ExportRendererAttribute(typeof(MyTimePicker), typeof(MyTimePickerRenderer))]
    namespace MyProject.iOS.Renderers
    {
        public class MyTimePickerRenderer : PickerRenderer
        {
            internal static  IDevice Device;
            internal const int ComponentCount = 6;
            private const int _labelSize = 30;
            private MyTimePicker _myTimePicker;
            public MyTimePickerRenderer()
            {
                // This is dependent on XForms (see Update note)
                Device = Resolver.Resolve<IDevice>();
            }
            protected override void OnElementChanged (ElementChangedEventArgs<Picker> e)
            {
                base.OnElementChanged (e);
                if (Control != null)
                {
                    Control.BorderStyle = UITextBorderStyle.None;
                    _myTimePicker = e.NewElement as MyTimePicker;
                    var customModelPickerView = new UIPickerView
                        {
                            Model = new MyTimePickerView(_myTimePicker)
                        };
                    SelectPickerValue(customModelPickerView, _myTimePicker);
                
                    CreatePickerLabels(customModelPickerView);
                    Control.InputView = customModelPickerView;
                }
            }
        private void SelectPickerValue(UIPickerView customModelPickerView, MyTimePicker myTimePicker)
        { 
            customModelPickerView.Select(new nint(myTimePicker.SelectedTime.Hours), 0, false);
            customModelPickerView.Select(new nint(myTimePicker.SelectedTime.Minutes), 2, false);
            customModelPickerView.Select(new nint(myTimePicker.SelectedTime.Seconds), 4, false);
        }
        private void CreatePickerLabels(UIPickerView customModelPickerView)
        {
            nfloat verticalPosition = (customModelPickerView.Frame.Size.Height / 2) - (_labelSize / 2);
            nfloat componentWidth = new nfloat(Device.Display.Width / ComponentCount / Device.Display.Scale);
            var hoursLabel = new UILabel(new CGRect(componentWidth, verticalPosition, _labelSize, _labelSize));
            hoursLabel.Text = "hrs";
            var minutesLabel = new UILabel(new CGRect((componentWidth * 3) + (componentWidth / 2), verticalPosition, _labelSize, _labelSize));
            minutesLabel.Text = "mins";
            var secondsLabel = new UILabel(new CGRect((componentWidth * 5) + (componentWidth / 2), verticalPosition, _labelSize, _labelSize));
            secondsLabel.Text = "secs";
            customModelPickerView.AddSubview(hoursLabel);
            customModelPickerView.AddSubview(minutesLabel);
            customModelPickerView.AddSubview(secondsLabel);
        }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control == null)
            {
                return;
            }
            if (e.PropertyName == "SelectedIndex")
            {
                var customModelPickerView = (UIPickerView)Control.InputView;
                SelectPickerValue(customModelPickerView, _myTimePicker);
            }
        }
        
        public class MyTimePickerView : UIPickerViewModel
        {
            private readonly MyTimePicker _myTimePicker;
            public MyTimePickerView(MyTimePicker picker)
            {
                _myTimePicker = picker;
            }
            public override nint GetComponentCount(UIPickerView pickerView)
            {
                return new nint(MyTimePickerRenderer.ComponentCount);
            }
            public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
            {
                if (component == 0)
                {
                    // Hours
                    return new nint(24);
                }
                if (component % 2 != 0)
                {
                    // Odd components are labels for hrs, mins and secs
                    return new nint(1);
                }
                // Minutes & seconds
                return new nint(60);
            }
            public override string GetTitle(UIPickerView pickerView, nint row, nint component)
            {
                if (component == 0)
                {
                    return row.ToString();
                }
                else if (component == 1)
                {
                    return null;
                }
                else if (component == 3)
                {
                    return null;
                }
                else if (component == 5)
                {
                    return null;
                }
                return row.ToString("00");
            }
            public override void Selected(UIPickerView pickerView, nint row, nint component)
            {
                var selectedHours = pickerView.SelectedRowInComponent(0);
                var selectedMinutes = pickerView.SelectedRowInComponent(2);
                var selectedSeconds = pickerView.SelectedRowInComponent(4);
                var time = new TimeSpan((int)selectedHours, (int)selectedMinutes, (int)selectedSeconds);
                _myTimePicker.SelectedTime = time;
            }
            public override nfloat GetComponentWidth(UIPickerView pickerView, nint component)
            {
                var screenWidth = MyTimePickerRenderer.Device.Display.Width;
                var componentWidth = screenWidth /
                    MyTimePickerRenderer.ComponentCount /
                    MyTimePickerRenderer.Device.Display.Scale;
            
                return new nfloat(componentWidth);
            }
        }
    }
