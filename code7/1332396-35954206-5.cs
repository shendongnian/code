    public class MyTimePicker : Picker
    {
        public static readonly BindableProperty SelectedTimeProperty =
        BindableProperty.Create<MyTimePicker, TimeSpan>(p => p.SelectedTime, TimeSpan.MinValue, BindingMode.TwoWay,propertyChanged: OnSelectedTimePropertyPropertyChanged);
        public MyTimePicker()
        {
            // Ugly hack since Xamarin Forms' Picker uses only one component internally
            // This is a list of all possible timespan from 0:00:00 to 23:59:59
            for (int hour = 0; hour < 24; hour++)
            {
                for (int minute = 0; minute < 60; minute ++)
                {
                    for (int second = 0; second < 60; second++)
                    {
                        Items.Add(string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second));
                    }
                }
            }
            base.SelectedIndexChanged += (o, e) =>
            {
                if (base.SelectedIndex < 0)
                {
                    SelectedTime = TimeSpan.MinValue;
                    return;
                }
                int index = 0;
                foreach (var item in Items)
                {
                    if (index == SelectedIndex)
                    {
                        SelectedTime = TimeSpan.Parse(item);
                        break;
                    }
                    index++;
                }
            };
        }
        public TimeSpan SelectedTime
        {
            get { return (TimeSpan)GetValue(SelectedTimeProperty); }
            set { SetValue(SelectedTimeProperty, value); }
        }
        private static void OnSelectedTimePropertyPropertyChanged(BindableObject bindable, TimeSpan value, TimeSpan newValue)
        {
            var picker = (MyTimePicker)bindable;
            var itemMatch = picker.Items.FirstOrDefault(x => x == newValue.ToString());
            var index = picker.Items.IndexOf(itemMatch);
            picker.SelectedIndex = index;
        }
    }
