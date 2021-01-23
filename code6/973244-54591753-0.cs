    /// <summary>
    /// Set the ScrollBars of a ScrollViewer to Hidden (instead of Collasped) when they are not needed.
    /// </summary>
    /// <seealso cref="MTM.UI.Behaviors.FrameworkElementBehaviorBase{System.Windows.Controls.ScrollViewer}" />
    public class ScrollViewerHiddenScrollbarsBehaviour : FrameworkElementBehaviorBase<ScrollViewer>
    {
        private ScrollBar _verticalScrollBar;
        private ScrollBar _horizontalScrollBar;
        /// <summary>
        /// Setup the Behaviour
        /// </summary>
        protected override void Setup()
        {
            AssociatedObject.Loaded += OnLoaded;
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            // Getting the ScrollBars IF they are set to ScrollBarVisibility.Auto
            _verticalScrollBar = AssociatedObject.VerticalScrollBarVisibility != ScrollBarVisibility.Auto ? null :
                AssociatedObject.Template.FindName("PART_VerticalScrollBar", AssociatedObject) as ScrollBar;
            _horizontalScrollBar = AssociatedObject.HorizontalScrollBarVisibility != ScrollBarVisibility.Auto ? null :
                AssociatedObject.Template.FindName("PART_HorizontalScrollBar", AssociatedObject) as ScrollBar;
            if (_verticalScrollBar != null) {
                // When changing the Visibility of the ScrollBar directly it won't get updated anymore when the ScrollViewer
                // needs it. So let's do this manually.
                DependencyPropertyDescriptor
                  .FromProperty(ScrollViewer.ComputedVerticalScrollBarVisibilityProperty, typeof(ScrollViewer))
                  .AddValueChanged(AssociatedObject, VerticalHandler);
                VerticalHandler(null, null);
            }
            if (_horizontalScrollBar != null) {
                // When changing the Visibility of the ScrollBar directly it won't get updated anymore when the ScrollViewer
                // needs it. So let's do this manually.
                DependencyPropertyDescriptor
                    .FromProperty(ScrollViewer.ComputedHorizontalScrollBarVisibilityProperty, typeof(ScrollViewer))
                    .AddValueChanged(AssociatedObject, HorizontalHandler);
                HorizontalHandler(null, null);
            }
        }
        /// <summary>
        /// Sets the Visibility of the vertical ScrollBar as needed by the ScrollViewer, BUT Hidden instead of collapsed
        /// </summary>
        private void VerticalHandler(object sender, EventArgs e)
        {
            if (_verticalScrollBar == null)
                return;
            _verticalScrollBar.Visibility = AssociatedObject.ComputedVerticalScrollBarVisibility == Visibility.Visible
                ? Visibility.Visible
                : Visibility.Hidden;
        }
        /// <summary>
        /// Sets the Visibility of the horizontal ScrollBar as needed by the ScrollViewer, BUT Hidden instead of collapsed
        /// </summary>
        private void HorizontalHandler(object sender, EventArgs e)
        {
            if (_horizontalScrollBar == null)
                return;
            _horizontalScrollBar.Visibility = AssociatedObject.ComputedHorizontalScrollBarVisibility == Visibility.Visible
                ? Visibility.Visible
                : Visibility.Hidden;
        }
        /// <summary>
        /// Cleanup the Behaviour
        /// </summary>
        protected override void Cleanup()
        {
            AssociatedObject.Loaded -= OnLoaded;
            DependencyPropertyDescriptor
                .FromProperty(ScrollViewer.ComputedVerticalScrollBarVisibilityProperty, typeof(ScrollViewer))
                .RemoveValueChanged(AssociatedObject, VerticalHandler);
            DependencyPropertyDescriptor
                .FromProperty(ScrollViewer.ComputedHorizontalScrollBarVisibilityProperty, typeof(ScrollViewer))
                .RemoveValueChanged(AssociatedObject, HorizontalHandler);
        }
    }
