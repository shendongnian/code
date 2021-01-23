    public class NullableTimePicker : ContentView
                {
                    private const string NullTimeLabel = "hh : mm";
                    private readonly TimePicker _timePicker;
                    private readonly Label _label;
            
                    public static readonly BindableProperty TimeProperty = BindableProperty.Create<NullableTimePicker, TimeSpan?>(t => t.Time, null, BindingMode.TwoWay, propertyChanged: OnTimeChanged);
            
                    public NullableTimePicker()
                    {
                        _label = new Label
                        {
                            Text = NullTimeLabel,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.Fill,
                            HorizontalTextAlignment = TextAlignment.Start,
                            VerticalTextAlignment = TextAlignment.Center,
                            TextColor = Color.Black,
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                        };
            
                        _timePicker = new TimePicker
                        {
                            IsVisible = false,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.Fill
                        };
            
                        Content = new StackLayout
                        {
                            Children =
                            {
                                _label,
                                _timePicker
                            },
                            Padding = 0,
                            Spacing = 0,
                            Margin = 0
                        };
            
                        Padding = 0;
                        Margin = 0;
            
                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
                        GestureRecognizers.Add(tapGestureRecognizer);
            
                        _timePicker.PropertyChanged += timePicker_PropertyChanged;
            
                        PropertyChanged += NullableTimePicker_PropertyChanged;
                    }
            
                    private void NullableTimePicker_PropertyChanged(object sender, PropertyChangedEventArgs e)
                    {
                        if (_label != null && e.PropertyName == IsEnabledProperty.PropertyName)
                        {
                            _label.TextColor = IsEnabled ? Color.Black : Color.Gray;
                        }
                    }
            
                    private void timePicker_PropertyChanged(object sender, PropertyChangedEventArgs e)
                    {
                        if (e.PropertyName == TimePicker.TimeProperty.PropertyName && _timePicker != null)
                        {
                            Time = _timePicker.Time;
                        }
                    }
            
                    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
                    {
                        if (IsEnabled == false)
                        {
                            return;
                        }
            
                        if (_timePicker.IsFocused)
                        {
                            _timePicker.Unfocus();
                        }
            
                        _timePicker.Focus();
                    }
            
                    private static void OnTimeChanged(BindableObject bindable, TimeSpan? oldvalue, TimeSpan? newvalue)
                    {
                        var nullableTimePicker = bindable as NullableTimePicker;
                        if (nullableTimePicker != null && oldvalue != newvalue)
                        {
                            nullableTimePicker.Time = newvalue;
                        }
                    }
            
                    public TimeSpan? Time
                    {
                        get
                        {
                            return GetValue(TimeProperty) as TimeSpan?;
                        }
                        set
                        {
                            SetValue(TimeProperty, value);
            
                            if (value.HasValue && _timePicker.Time != value)
                            {
                                _timePicker.Time = value.Value;
                            }
                            SetLabelText(value);
                        }
                    }
            
                    private void SetLabelText(TimeSpan? value)
                    {
                        _label.Text = value.HasValue ? ConvertTimeSpanToString(value.Value) : NullTimeLabel;
                    }
        
                   private string ConvertTimeSpanToString(TimeSpan? timeSpan)
                  {
                    if (timeSpan == null)
                    {
                        return string.Empty;
                    }
        
                    var hoursIn24HrFormat = int.Parse(timeSpan.Value.ToString("hh", CultureInfo.InvariantCulture));
                    var minutes = int.Parse(timeSpan.Value.ToString("mm", CultureInfo.InvariantCulture));
        
                    var hoursIn12HrFormat = hoursIn24HrFormat > 12 ? hoursIn24HrFormat - 12 : hoursIn24HrFormat;
        
                    var timeString = hoursIn12HrFormat.ToString("00") + ":" + minutes.ToString("00") + " " +
                                     (hoursIn24HrFormat >= 12 ? "PM" : "AM");
                    return timeString;
                }
                }
