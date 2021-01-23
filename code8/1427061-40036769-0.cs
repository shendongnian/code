    public sealed partial class MainPage : Page
    {
        private bool _isScroll = false;
        private bool _isSlide = false;
        public MainPage()
        {
            this.InitializeComponent();
            var vm = new ViewModel();
            vm.ValueChanged += LetterSliderValueChanged;
            DataContext = vm;
        }
        /// <summary>
        /// Bring list items into view on the screen based on the value (letter) of the slider
        /// </summary>
        /// <param name="sender">The view model to bring into view</param>
        private void LetterSliderValueChanged(object sender, RoutedEventArgs e)
        {
            if (_isScroll) return;
            if (sender == null) return;
            _isSlide = true;
            ListView?.ScrollIntoView(sender, ScrollIntoViewAlignment.Leading);
        }
        /// <summary>
        /// Update the position of the slider when the ListView is scrolling from a normal touch
        /// </summary>
        private void ScrollViewerViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (_isSlide)
            {
                _isSlide = false;
                return;
            }
            _isScroll = true;
            var scrollViewer = sender as ScrollViewer;
            var scrollBars = scrollViewer.GetDescendantsOfType<ScrollBar>();
            var verticalBar = scrollBars.FirstOrDefault(x => x.Orientation == Orientation.Vertical);
            // Normalize the scales to move the slider thumb in sync with scrolling
            var sliderTotal = LetterSlider.Maximum - LetterSlider.Minimum;
            var barTotal = verticalBar.Maximum - verticalBar.Minimum;
            var barPercent = verticalBar.Value / barTotal;
            LetterSlider.Value = (barPercent * sliderTotal) + LetterSlider.Minimum;
            _isScroll = false;
        }
        /// <summary>
        /// Add the slider method to the ListView's ScrollViewer Viewchanged event
        /// </summary>
        private void ListViewLoaded(object sender, RoutedEventArgs e)
        {
            var listview = sender as ListView;
            if (listview == null) return;
            var scrollViewer = listview.GetFirstDescendantOfType<ScrollViewer>();
            scrollViewer.ViewChanged -= ScrollViewerViewChanged;
            scrollViewer.ViewChanged += ScrollViewerViewChanged;
        }
    }
