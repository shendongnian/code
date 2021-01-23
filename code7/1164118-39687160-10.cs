        public class Checkbox : ContentView
    {
        protected Grid ContentGrid;
        protected ContentView ContentContainer;
        public Label TextContainer;
        protected Image ImageContainer;
        public Checkbox()
        {
            var TapGesture = new TapGestureRecognizer();
            TapGesture.Tapped += TapGestureOnTapped;
            GestureRecognizers.Add(TapGesture);
            ContentGrid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            ContentGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(42) });
            ContentGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            ContentGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            ImageContainer = new Image
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };
            ImageContainer.HeightRequest = 42;
            ImageContainer.WidthRequest = 42;
            ContentGrid.Children.Add(ImageContainer);
            ContentContainer = new ContentView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            Grid.SetColumn(ContentContainer, 1);
            TextContainer = new Label
            {
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            ContentContainer.Content = TextContainer;
            ContentGrid.Children.Add(ContentContainer);
            
            base.Content = ContentGrid;
            this.Image.Source = "Image_Unchecked.png";
            this.BackgroundColor = Color.Transparent;
        }
        public static BindableProperty CheckedProperty = BindableProperty.Create(
            propertyName: "Checked",
            returnType: typeof(Boolean?),
            declaringType: typeof(Checkbox),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: CheckedValueChanged);
        
        public static BindableProperty TextProperty = BindableProperty.Create(
            propertyName: "Text",
            returnType: typeof(String),
            declaringType: typeof(Checkbox),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: TextValueChanged);
        public Boolean? Checked
        {
            get
            {
                if (GetValue(CheckedProperty) == null)
                    return null;
                return (Boolean)GetValue(CheckedProperty);
            }
            set
            {
                SetValue(CheckedProperty, value);
                OnPropertyChanged();
                RaiseCheckedChanged();
            }
        }
        
        private static void CheckedValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null && (Boolean)newValue == true)
                ((Checkbox)bindable).Image.Source = "Image_Checked.png";
            else
                ((Checkbox)bindable).Image.Source = "Image_Unchecked.png";
        }
        public event EventHandler CheckedChanged;
        private void RaiseCheckedChanged()
        {
            if (CheckedChanged != null)
                CheckedChanged(this, EventArgs.Empty);
        }
        private Boolean _IsEnabled = true;
        public Boolean IsEnabled
        {
            get { return _IsEnabled; }
            set
            {
                _IsEnabled = value;
                OnPropertyChanged();
                this.Opacity = value ? 1 : .5;
                base.IsEnabled = value;
            }
        }
        public event EventHandler Clicked;
        private void TapGestureOnTapped(object sender, EventArgs eventArgs)
        {
            if (IsEnabled)
            {
                Checked = !Checked;
                if (Clicked != null)
                    Clicked(this, new EventArgs());
            }
        }
        private static void TextValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((Checkbox)bindable).TextContainer.Text = (String)newValue;
        }
        public event EventHandler TextChanged;
        private void RaiseTextChanged()
        {
            if (TextChanged != null)
                TextChanged(this, EventArgs.Empty);
        }
        public Image Image
        {
            get { return ImageContainer; }
            set { ImageContainer = value; }
        }
        public String Text
        {
            get { return (String)GetValue(TextProperty); }
            set
            {
                SetValue(TextProperty, value);
                OnPropertyChanged();
                RaiseTextChanged();
            }
        }
    }
