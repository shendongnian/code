    xmlns:local="clr-namespace:WpfApplication156"
                 xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                 Width="{Binding RelativeSource={RelativeSource Self},
                                 Path=Height,
                                 Mode=TwoWay}"
                 Height="120"
                 Background="Transparent"
                 IsVisibleChanged="HandleVisibleChanged"
                 Opacity="0"
                 Visibility="Hidden">
        <Viewbox HorizontalAlignment="Stretch" VerticalAlignment="Stretch">
            <Canvas Width="120"
                    Height="120"
                    HorizontalAlignment="Center"
                    VerticalAlignment="Center"
                    Loaded="HandleLoaded"
                    RenderTransformOrigin="0.5,0.5"
                    Unloaded="HandleUnloaded">
                <Canvas.Resources>
                    <Style TargetType="Ellipse">
                        <Setter Property="Width" Value="20" />
                        <Setter Property="Height" Value="20" />
                        <Setter Property="Stretch" Value="Fill" />
                        <Setter Property="Fill">
                            <Setter.Value>
                                <Binding Path="Foreground">
                                    <Binding.RelativeSource>
                                        <RelativeSource AncestorType="{x:Type local:ProgressBar}" Mode="FindAncestor" />
                                    </Binding.RelativeSource>
                                </Binding>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </Canvas.Resources>
                <Ellipse x:Name="C0" Opacity="1.0" />
                <Ellipse x:Name="C1" Opacity="0.9" />
                <Ellipse x:Name="C2" Opacity="0.8" />
                <Ellipse x:Name="C3" Opacity="0.7" />
                <Ellipse x:Name="C4" Opacity="0.6" />
                <Ellipse x:Name="C5" Opacity="0.5" />
                <Ellipse x:Name="C6" Opacity="0.4" />
                <Ellipse x:Name="C7" Opacity="0.3" />
                <Ellipse x:Name="C8" Opacity="0.2" />
                <Canvas.RenderTransform>
                    <RotateTransform x:Name="SpinnerRotate" Angle="0" />
                </Canvas.RenderTransform>
            </Canvas>
        </Viewbox>
    </UserControl>
    public partial class ProgressBar
        {
            #region Public Fields
    
            /// <summary>
            /// Spinning Speed. Default is 60, that's one rotation per second.
            /// </summary>
            public static readonly DependencyProperty RotationsPerMinuteProperty =
                DependencyProperty.Register(
                    "RotationsPerMinute",
                    typeof(double),
                    typeof(ProgressBar),
                    new PropertyMetadata(60.0));
    
            /// <summary>
            /// Startup time in milliseconds, default is a second.
            /// </summary>
            public static readonly DependencyProperty StartupDelayProperty =
                DependencyProperty.Register(
                    "StartupDelay",
                    typeof(int),
                    typeof(ProgressBar),
                    new PropertyMetadata(1000));
    
            #endregion Public Fields
    
            #region Private Fields
    
            /// <summary>
            /// Timer for the Animation.
            /// </summary>
            private readonly DispatcherTimer animationTimer;
    
            /// <summary>
            /// Mouse Cursor.
            /// </summary>
            private Cursor originalCursor;
    
            #endregion Private Fields
    
            #region Public Constructors
    
            /// <summary>
            /// Initializes a new instance of the ProgressBar class.
            /// </summary>
            public ProgressBar()
            {
                InitializeComponent();
    
                this.animationTimer = new DispatcherTimer(DispatcherPriority.Normal, Dispatcher);
            }
    
            #endregion Public Constructors
    
            #region Public Properties
    
            /// <summary>
            /// Gets or sets the spinning speed. Default is 60, that's one rotation per second.
            /// </summary>
            public double RotationsPerMinute
            {
                get
                {
                    return (double)this.GetValue(RotationsPerMinuteProperty);
                }
    
                set
                {
                    this.SetValue(RotationsPerMinuteProperty, value);
                }
            }
    
            /// <summary>
            /// Gets or sets the startup time in milliseconds, default is a second.
            /// </summary>
            public int StartupDelay
            {
                get
                {
                    return (int)this.GetValue(StartupDelayProperty);
                }
    
                set
                {
                    this.SetValue(StartupDelayProperty, value);
                }
            }
    
            #endregion Public Properties
    
            #region Private Methods
    
            /// <summary>
            /// Apply a single rotation transformation.
            /// </summary>
            /// <param name="sender">Sender of the Event: the Animation Timer.</param>
            /// <param name="e">Event arguments.</param>
            private void HandleAnimationTick(object sender, EventArgs e)
            {
                this.SpinnerRotate.Angle = (this.SpinnerRotate.Angle + 36) % 360;
            }
    
            /// <summary>
            /// Control was loaded: distribute circles.
            /// </summary>
            /// <param name="sender">Sender of the Event: I wish I knew.</param>
            /// <param name="e">Event arguments.</param>
            private void HandleLoaded(object sender, RoutedEventArgs e)
            {
                this.SetPosition(C0, 0.0);
                this.SetPosition(C1, 1.0);
                this.SetPosition(C2, 2.0);
                this.SetPosition(C3, 3.0);
                this.SetPosition(C4, 4.0);
                this.SetPosition(C5, 5.0);
                this.SetPosition(C6, 6.0);
                this.SetPosition(C7, 7.0);
                this.SetPosition(C8, 8.0);
            }
    
            /// <summary>
            /// Control was unloaded: stop spinning.
            /// </summary>
            /// <param name="sender">Sender of the event.</param>
            /// <param name="e">Event arguments.</param>
            private void HandleUnloaded(object sender, RoutedEventArgs e)
            {
                this.StopSpinning();
            }
    
            /// <summary>
            /// Visibility property was changed: start or stop spinning.
            /// </summary>
            /// <param name="sender">Sender of the event.</param>
            /// <param name="e">Event arguments.</param>
            private void HandleVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                // Don't give the developer a headache.
                ////if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                ////{
                ////    return;
                ////}
    
                bool isVisible = (bool)e.NewValue;
    
                if (isVisible)
                {
                    this.StartDelay();
                }
                else
                {
                    this.StopSpinning();
                }
            }
    
            /// <summary>
            /// Calculate position of a circle.
            /// </summary>
            /// <param name="ellipse">The circle.</param>
            /// <param name="sequence">Sequence number of the circle.</param>
            private void SetPosition(Ellipse ellipse, double sequence)
            {
                ellipse.SetValue(
                    Canvas.LeftProperty,
                    50.0 + (Math.Sin(Math.PI * ((0.2 * sequence) + 1)) * 50.0));
    
                ellipse.SetValue(
                    Canvas.TopProperty,
                    50 + (Math.Cos(Math.PI * ((0.2 * sequence) + 1)) * 50.0));
            }
    
            /// <summary>
            /// Startup Delay.
            /// </summary>
            private void StartDelay()
            {
                this.originalCursor = Mouse.OverrideCursor;
                Mouse.OverrideCursor = Cursors.Wait;
    
                // Startup
                this.animationTimer.Interval = new TimeSpan(0, 0, 0, 0, this.StartupDelay);
                this.animationTimer.Tick += this.StartSpinning;
                this.animationTimer.Start();
            }
    
            /// <summary>
            /// Start Spinning.
            /// </summary>
            /// <param name="sender">Sender of the event.</param>
            /// <param name="e">Event Arguments.</param>
            private void StartSpinning(object sender, EventArgs e)
            {
                this.animationTimer.Stop();
                this.animationTimer.Tick -= this.StartSpinning;
    
                // 60 secs per minute, 1000 millisecs per sec, 10 rotations per full circle:
                this.animationTimer.Interval = new TimeSpan(0, 0, 0, 0, (int)(6000 / this.RotationsPerMinute));
                this.animationTimer.Tick += this.HandleAnimationTick;
                this.animationTimer.Start();
                this.Opacity = 1;
    
                Mouse.OverrideCursor = this.originalCursor;
            }
    
            /// <summary>
            /// The control became invisible: stop spinning (animation consumes CPU).
            /// </summary>
            private void StopSpinning()
            {
                this.animationTimer.Stop();
                this.animationTimer.Tick -= this.HandleAnimationTick;
                this.Opacity = 0;
            }
    
            #endregion Private Methods
        }
