    public class AutoCompleteComboBox : AutoCompleteBox
    {
        /// <summary>
        /// Occurs when drop down toggle button is clicked.
        /// </summary>
        public event EventHandler ToggleButtonClick;
        private object _holdSelectedItem;
        private AutoCompleteFilterMode _holdFilterMode;
        /// <summary>
        /// Identifies the DisplayMemberPath dependency property.
        /// </summary>
        public static readonly DependencyProperty DisplayMemberPathProperty = DependencyProperty.Register("DisplayMemberPath", typeof(string), typeof(AutoCompleteComboBox), new PropertyMetadata(string.Empty, DisplayMemberPath_PropertyChanged));
        /// <summary>
        /// Gets or sets the name or path of the property 
        /// that is displayed for each the data item in the control.
        /// </summary>
        public string DisplayMemberPath
        {
            get { return (string)GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }
        private static void DisplayMemberPath_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var accb = (AutoCompleteComboBox)d;
            accb.ValueMemberPath = e.NewValue.ToString();
        }
        /// <summary>
        /// Identifies the MaxLength dependency property.
        /// </summary>
        public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.Register("MaxLength", typeof(int), typeof(AutoCompleteComboBox), null);
        /// <summary>
        /// Gets or sets the maximum number of characters allowed for user input.
        /// </summary>
        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }
        /// <summary>
        /// Gets or sets a collection used to generate the content of the control.
        /// </summary>
        public new IEnumerable ItemsSource
        {
            get { return GetValue(ItemsSourceProperty) as IEnumerable; }
            set
            {
                SetValue(SelectedItemProperty, null);
                SetValue(ItemsSourceProperty, value);
                Dispatcher.BeginInvoke(() => SetValue(TextProperty, string.Empty));
                _holdSelectedItem = null;
            }
        }
        /// <summary>
        /// Initializes a new instance of the AutoCompleteComboBox control.
        /// </summary>
        public AutoCompleteComboBox()
        {
            StreamResourceInfo sri = Application.GetResourceStream(new Uri("/UI.Controls;component/AutoCompleteComboBox.xaml", UriKind.Relative));
            var sr = new StreamReader(sri.Stream);
            Style = (Style)XamlReader.Load(sr.ReadToEnd());
            DropDownClosed += AutoCompleteComboBox_DropDownClosed;
            DropDownOpened += AutoCompleteComboBox_DropDownOpened;
        }
        /// <summary>
        /// Called when the template's tree is generated.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var toggle = (ToggleButton)GetTemplateChild("PopupToggleButton");
            toggle.Click += DropDownToggle_Click;
            var lb = (ListBox)GetTemplateChild("Selector");
            lb.DisplayMemberPath = DisplayMemberPath;
            _holdFilterMode = FilterMode;
            TextChanged += AutoCompleteComboBox_TextChanged;
            SelectionChanged += new SelectionChangedEventHandler(AutoCompleteComboBox_SelectionChanged);
        }
        private void AutoCompleteComboBox_DropDownClosed(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            if (SelectedItem == null && _holdSelectedItem != null && SelectedItem != _holdSelectedItem && ItemsSource.Cast<object>().Contains(_holdSelectedItem))
            {
                SelectedItem = _holdSelectedItem;
            }
            _holdSelectedItem = null;
            FilterMode = _holdFilterMode;
        }
        private void AutoCompleteComboBox_DropDownOpened(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            var lb = (ListBox)GetTemplateChild("Selector");
            ScrollViewer sv = lb.GetScrollHost();
            if (sv != null)
            {
                sv.ScrollToTop();
            }
            if (SelectedItem != null)
            {
                lb.SelectedItem = SelectedItem;
                _holdSelectedItem = SelectedItem;
            }
        }
        private void DropDownToggle_Click(object sender, RoutedEventArgs e)
        {
            IsDropDownOpen = !IsDropDownOpen;
            if (ToggleButtonClick != null)
            {
                ToggleButtonClick(this, e);
            }
            if (IsDropDownOpen)
            {
                _holdFilterMode = FilterMode;
                FilterMode = AutoCompleteFilterMode.None;
                ((TextBox)GetTemplateChild("Text")).SelectAll();
            }
            Focus();
        }
        private void AutoCompleteComboBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (IsDropDownOpen)
            {
                if (FilterMode == AutoCompleteFilterMode.None && FilterMode != _holdFilterMode)
                {
                    FilterMode = _holdFilterMode;
                }
                ScrollViewer sv = ((ListBox)GetTemplateChild("Selector")).GetScrollHost();
                if (sv != null)
                {
                    sv.ScrollToTop();
                }
            }
        }
        private void AutoCompleteComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsDropDownOpen && SelectedItem == null)
            {
                Text = string.Empty;
            }
        }
    }
-----------------------------
    <Setter Property="Height" Value="24" />
    <Setter Property="MinimumPopulateDelay" Value="1" />
    <Setter Property="IsTextCompletionEnabled" Value="False" />
    <Setter Property="MinimumPrefixLength" Value="0" />
    <Setter Property="MaxDropDownHeight" Value="300" />
    <Setter Property="IsTabStop" Value="False" />
    <Setter Property="Padding" Value="2" />
    <Setter Property="BorderThickness" Value="1" />
    <Setter Property="BorderBrush" Value="#FF000000" />
    <Setter Property="Background" Value="#FFFFFFFF" />
    <Setter Property="Foreground" Value="#FF000000" />
    <Setter Property="MinWidth" Value="45" />
    <Setter Property="FilterMode" Value="Contains" />
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="ctrls:AutoCompleteComboBox">
                <Grid >
                    <Grid.Resources>
                        <Style x:Name="comboToggleStyle" TargetType="ToggleButton">
                            <Setter Property="Foreground" Value="#FF333333"/>
                            <Setter Property="Background" Value="#FF1F3B53"/>
                            <Setter Property="BorderBrush">
                                <Setter.Value>
                                    <LinearGradientBrush EndPoint="0.5,1" StartPoint="0.5,0">
                                        <GradientStop Color="#FFA3AEB9" Offset="0"/>
                                        <GradientStop Color="#FF8399A9" Offset="0.375"/>
                                        <GradientStop Color="#FF718597" Offset="0.375"/>
                                        <GradientStop Color="#FF617584" Offset="1"/>
                                    </LinearGradientBrush>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="BorderThickness" Value="1"/>
                            <Setter Property="Padding" Value="3"/>
                            <Setter Property="Template">
                                <Setter.Value>
                                    <ControlTemplate TargetType="ToggleButton">
                                        <Grid>
                                            <VisualStateManager.VisualStateGroups>
                                                <VisualStateGroup x:Name="CommonStates">
                                                    <VisualState x:Name="Normal"/>
                                                    <VisualState x:Name="MouseOver">
                                                        <Storyboard>
                                                            <DoubleAnimation Duration="0" Storyboard.TargetName="BackgroundOverlay" Storyboard.TargetProperty="Opacity" To="1"/>
                                                            <ColorAnimation Duration="0" Storyboard.TargetName="BackgroundGradient" Storyboard.TargetProperty="(Shape.Fill).(GradientBrush.GradientStops)[3].(GradientStop.Color)" To="#7FFFFFFF"/>
                                                            <ColorAnimation Duration="0" Storyboard.TargetName="BackgroundGradient" Storyboard.TargetProperty="(Shape.Fill).(GradientBrush.GradientStops)[2].(GradientStop.Color)" To="#CCFFFFFF"/>
                                                            <ColorAnimation Duration="0" Storyboard.TargetName="BackgroundGradient" Storyboard.TargetProperty="(Shape.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Color)" To="#F2FFFFFF"/>
                                                        </Storyboard>
                                                    </VisualState>
                                                    <VisualState x:Name="Pressed">
                                                        <Storyboard>
                                                            <DoubleAnimation Duration="0" Storyboard.TargetName="BackgroundOverlay2" Storyboard.TargetProperty="Opacity" To="1"/>
                                                            <DoubleAnimation Duration="0" Storyboard.TargetName="Highlight" Storyboard.TargetProperty="(UIElement.Opacity)" To="1"/>
                                                            <ColorAnimation Duration="0" Storyboard.TargetName="BackgroundGradient" Storyboard.TargetProperty="(Shape.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Color)" To="#E5FFFFFF"/>
                                                            <ColorAnimation Duration="0" Storyboard.TargetName="BackgroundGradient" Storyboard.TargetProperty="(Shape.Fill).(GradientBrush.GradientStops)[2].(GradientStop.Color)" To="#BCFFFFFF"/>
                                                            <ColorAnimation Duration="0" Storyboard.TargetName="BackgroundGradient" Storyboard.TargetProperty="(Shape.Fill).(GradientBrush.GradientStops)[3].(GradientStop.Color)" To="#6BFFFFFF"/>
                                                            <ColorAnimation Duration="0" Storyboard.TargetName="BackgroundGradient" Storyboard.TargetProperty="(Shape.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Color)" To="#F2FFFFFF"/>
                                                        </Storyboard>
                                                    </VisualState>
                                                    <VisualState x:Name="Disabled" />
                                                </VisualStateGroup>
                                                <VisualStateGroup x:Name="CheckStates">
                                                    <VisualState x:Name="Checked">
                                                        <Storyboard>
                                                            <DoubleAnimation Duration="0" Storyboard.TargetName="BackgroundOverlay3" Storyboard.TargetProperty="(UIElement.Opacity)" To="1"/>
                                                            <DoubleAnimation Duration="0" Storyboard.TargetName="Highlight" Storyboard.TargetProperty="(UIElement.Opacity)" To="1"/>
                                                            <DoubleAnimation Duration="0" Storyboard.TargetName="BackgroundGradient2" Storyboard.TargetProperty="(UIElement.Opacity)" To="1"/>
                                                            <ColorAnimation Duration="0" Storyboard.TargetName="BackgroundGradient2" Storyboard.TargetProperty="(Shape.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Color)" To="#E5FFFFFF"/>
                                                            <ColorAnimation Duration="0" Storyboard.TargetName="BackgroundGradient2" Storyboard.TargetProperty="(Shape.Fill).(GradientBrush.GradientStops)[2].(GradientStop.Color)" To="#BCFFFFFF"/>
                                                            <ColorAnimation Duration="0" Storyboard.TargetName="BackgroundGradient2" Storyboard.TargetProperty="(Shape.Fill).(GradientBrush.GradientStops)[3].(GradientStop.Color)" To="#6BFFFFFF"/>
                                                            <ColorAnimation Duration="0" Storyboard.TargetName="BackgroundGradient2" Storyboard.TargetProperty="(Shape.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Color)" To="#F2FFFFFF"/>
                                                        </Storyboard>
                                                    </VisualState>
                                                    <VisualState x:Name="Unchecked"/>
                                                </VisualStateGroup>
                                                <VisualStateGroup x:Name="FocusStates">
                                                    <VisualState x:Name="Focused">
                                                        <Storyboard>
                                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="FocusVisualElement" Storyboard.TargetProperty="Visibility" Duration="0">
                                                                <DiscreteObjectKeyFrame KeyTime="0">
                                                                    <DiscreteObjectKeyFrame.Value>
                                                                        <Visibility>Visible</Visibility>
                                                                    </DiscreteObjectKeyFrame.Value>
                                                                </DiscreteObjectKeyFrame>
                                                            </ObjectAnimationUsingKeyFrames>
                                                        </Storyboard>
                                                    </VisualState>
                                                    <VisualState x:Name="Unfocused" />
                                                </VisualStateGroup>
                                            </VisualStateManager.VisualStateGroups>
                                            <Rectangle x:Name="Background" RadiusX="3" RadiusY="3" Fill="{TemplateBinding Background}" StrokeThickness="{TemplateBinding BorderThickness}" Stroke="{TemplateBinding BorderBrush}"/>
                                            <Rectangle x:Name="BackgroundOverlay" Opacity="0" RadiusX="3" RadiusY="3" Fill="#FF448DCA" StrokeThickness="{TemplateBinding BorderThickness}" Stroke="#00000000"/>
                                            <Rectangle x:Name="BackgroundOverlay2" Opacity="0" RadiusX="3" RadiusY="3" Fill="#FF448DCA" StrokeThickness="{TemplateBinding BorderThickness}" Stroke="#00000000"/>
                                            <Rectangle x:Name="BackgroundGradient" RadiusX="2" RadiusY="2" StrokeThickness="1" Margin="{TemplateBinding BorderThickness}" Stroke="#FFFFFFFF">
                                                <Rectangle.Fill>
                                                    <LinearGradientBrush StartPoint=".7,0" EndPoint=".7,1">
                                                        <GradientStop Color="#FFFFFFFF" Offset="0" />
                                                        <GradientStop Color="#F9FFFFFF" Offset="0.375" />
                                                        <GradientStop Color="#E5FFFFFF" Offset="0.625" />
                                                        <GradientStop Color="#C6FFFFFF" Offset="1" />
                                                    </LinearGradientBrush>
                                                </Rectangle.Fill>
                                            </Rectangle>
                                            <Rectangle Opacity="0" x:Name="BackgroundOverlay3" RadiusX="3" RadiusY="3" Fill="#FF448DCA" StrokeThickness="{TemplateBinding BorderThickness}" Stroke="#00000000"/>
                                            <Rectangle Opacity="0" x:Name="BackgroundGradient2" RadiusX="2" RadiusY="2" StrokeThickness="1" Margin="{TemplateBinding BorderThickness}" Stroke="#FFFFFFFF">
                                                <Rectangle.Fill>
                                                    <LinearGradientBrush StartPoint=".7,0" EndPoint=".7,1">
                                                        <GradientStop Color="#FFFFFFFF" Offset="0" />
                                                        <GradientStop Color="#F9FFFFFF" Offset="0.375" />
                                                        <GradientStop Color="#E5FFFFFF" Offset="0.625" />
                                                        <GradientStop Color="#C6FFFFFF" Offset="1" />
                                                    </LinearGradientBrush>
                                                </Rectangle.Fill>
                                            </Rectangle>
                                            <Rectangle x:Name="Highlight" RadiusX="2" RadiusY="2" Opacity="0" IsHitTestVisible="false" Stroke="#FF6DBDD1" StrokeThickness="1" Margin="{TemplateBinding BorderThickness}" />
                                            <ContentPresenter
                                                      x:Name="contentPresenter"
                                                      Content="{TemplateBinding Content}"
                                                      ContentTemplate="{TemplateBinding ContentTemplate}"
                                                      HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                                      VerticalAlignment="{TemplateBinding VerticalContentAlignment}"
                                                      Margin="{TemplateBinding Padding}"/>
                                            <Rectangle x:Name="FocusVisualElement" RadiusX="3.5" Margin="1"  RadiusY="3.5" Stroke="#FF6DBDD1" StrokeThickness="1" Visibility="Collapsed" IsHitTestVisible="false" />
                                        </Grid>
                                    </ControlTemplate>
                                </Setter.Value>
                            </Setter>
                        </Style>
