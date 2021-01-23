    [assembly: ExportRendererAttribute(typeof(MyTimePicker), typeof(MyTimePickerRenderer))]
    namespace MyProject.iOS.Renderers
    {
        public class MyTimePickerRenderer : PickerRenderer
        {
            protected override void OnElementChanged (ElementChangedEventArgs<Picker> e)
            {
                base.OnElementChanged (e);
               if (Control != null)
               {
                   var customModelPickerView = new UIPickerView
                   {
                           Model = new MyTimePickerView(e.NewElement as MyTimePicker)
                    };
                Control.InputView = customModelPickerView;
            }
        }
    }
        
    public class MyTimePickerView : UIPickerViewModel
    {
        readonly MyTimePicker _myTimePicker;
        public MyTimePickerView(MyTimePicker myTimePicker)
        {
            _myTimePicker = myTimePicker;
        }
        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return new nint(6);
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
                return "hr";
            }
            else if (component == 3)
            {
                return "min";
            }
            else if (component == 5)
            {
                return "sec";
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
        }
    }
