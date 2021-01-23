    [TemplatePart(Name = PanelPartName, Type = typeof(DateBandPanel))]
    public class DateBand : Control
    {
        private const string PanelPartName = "CellPanel";
        public static readonly DependencyProperty ScrollOffsetProperty = DependencyProperty.Register(
            nameof(ScrollOffset), typeof(double), typeof(DateBand), new PropertyMetadata(
                (double)0, new PropertyChangedCallback((d, e) => ((DateBand)d).HandleScrollOffsetChanged(e))));
        private void HandleScrollOffsetChanged(DependencyPropertyChangedEventArgs e)
        {
            _panel?.InvalidateMeasure();
        }
        public double ScrollOffset
        {
            get { return (double)GetValue(ScrollOffsetProperty); }
            set { SetValue(ScrollOffsetProperty, value); }
        }
        public static readonly DependencyProperty CellTemplateProperty = DependencyProperty.Register(
            nameof(CellTemplate), typeof(DataTemplate), typeof(DateBand), new PropertyMetadata(
                null, new PropertyChangedCallback((d, e) => ((DateBand)d).HandleCellTemplateChanged(e))));
        private void HandleCellTemplateChanged(DependencyPropertyChangedEventArgs e)
        {
            _panel?.InvalidateMeasure();
        }
        public DataTemplate CellTemplate
        {
            get { return (DataTemplate)GetValue(CellTemplateProperty); }
            set { SetValue(CellTemplateProperty, value); }
        }
        private DateBandPanel _panel;
        public DateBand()
        {
            this.DefaultStyleKey = typeof(DateBand);
        }
        protected override void OnApplyTemplate()
        {
            if (_panel != null)
                _panel._band = null;
            base.OnApplyTemplate();
            _panel = GetTemplateChild(PanelPartName) as DateBandPanel;
            if (_panel != null)
                _panel._band = this;
        }
    }
    public class DateBandPanel : Panel
    {
        internal DateBand _band;
        private List<DateCell> _cells = new List<DateCell>();
        private DateTime _startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        private const double cSlotWidth = 5;
        private const double cSlotHeight = 26;
        protected override Size MeasureOverride(Size availableSize)
        {
            int usedCells = 0;
            double desiredWidth = 0;
            double desiredHeight = 0;
            if (!double.IsPositiveInfinity(availableSize.Height) && _band != null)
            {
                var index = (int)Math.Floor(_band.ScrollOffset);
                var offset = (index - _band.ScrollOffset) * cSlotHeight;
                while (offset < availableSize.Height)
                {
                    DateCell cell;
                    if (usedCells < _cells.Count)
                    {
                        cell = _cells[usedCells];
                    }
                    else
                    {
                        cell = new DateCell();
                        Children.Add(cell);
                        _cells.Add(cell);
                    }
                    usedCells++;
                    var cellValue = _startDate.AddMonths(index);
                    cell._offset = offset;
                    cell._width = DateTime.DaysInMonth(cellValue.Year, cellValue.Month) * cSlotWidth;
                    cell.Content = new CellData(cellValue);
                    cell.ContentTemplate = _band.CellTemplate;
                    cell.Measure(new Size(cell._width, cSlotHeight));
                    offset += cSlotHeight;
                    index++;
                    desiredHeight = Math.Max(desiredHeight, offset);
                    desiredWidth = Math.Max(desiredWidth, cell._width);
                }
            }
            if (usedCells < _cells.Count)
            {
                for (int i = usedCells; i < _cells.Count; i++)
                    Children.Remove(_cells[i]);
                _cells.RemoveRange(usedCells, _cells.Count - usedCells);
            }
            return new Size(desiredWidth, desiredHeight);
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (var cell in _cells)
                cell.Arrange(new Rect(0, cell._offset, cell._width, cell.DesiredSize.Height));
            return finalSize;
        }
    }
    public class CellData
    {
        public DateTime Date { get; }
        public CellData(DateTime date) { this.Date = date; }
    }
    public class DateCell : ContentControl
    {
        internal double _offset;
        internal double _width;
    }
    public class FormattingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;
            if (parameter == null)
                return value.ToString();
            return ((IFormattable)value).ToString((string)parameter, CultureInfo.CurrentCulture);
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Page_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            Scroll.Value -= e.GetCurrentPoint(this).Properties.MouseWheelDelta / 120.0;
        }
    }
