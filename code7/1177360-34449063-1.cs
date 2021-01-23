    public class PickerView: UIView
    {
	int _numberItemPerRow = 7;
	int _numberRows = 6;
	nfloat _itemSize = 40;
	UIColor _labelColor;
	UIColor _oneTouchColor;
	UIColor _twoTouchColor;
	List<CalendarButton> _buttons;
	public PickerView (UIColor lb, UIColor one, UIColor two)
	{
		_labelColor = lb;
		_oneTouchColor = one;
		_twoTouchColor = two;
	}
	public PickerView(IntPtr handle) : base(handle) {
		
	}
	public override void Draw (CoreGraphics.CGRect rect)
	{
		var height = CalculateHeight (rect.Width);
		this.Frame = new CoreGraphics.CGRect (rect.X, rect.Y, rect.Width, height);
		InitLayout ();
	}
	public override void SetNeedsLayout ()
	{
		base.SetNeedsLayout ();
	}
	/*
	 * Internal functions
	 */
	nfloat CalculateHeight(nfloat width)
	{
		_itemSize = width / 7;
		return (nfloat)(_itemSize * (_numberRows + 1) + 70);
	}
	void InitLayout ()
	{
		DateTime currentTime = DateTime.Now;
		// add date label - first row
		for (int i = 0; i < 7; i++) {
			UILabel lb = new UILabel ();
			lb.Frame = new CoreGraphics.CGRect (i * _itemSize, 0, _itemSize, _itemSize);
			lb.Text = Constants.DaysInWeek.ElementAt (i);
			lb.TextAlignment = UITextAlignment.Center;
			lb.ClipsToBounds = true;
			lb.Layer.CornerRadius = _itemSize / 2;
			lb.BackgroundColor = _labelColor;
			lb.Layer.BorderWidth = 1;
			lb.Layer.BorderColor = UIColor.Black.CGColor;
			this.AddSubview (lb);
		}
		// add month
		UILabel lbMonth = new UILabel();
		lbMonth.Frame = new CoreGraphics.CGRect (0, _itemSize, this.Bounds.Width, 70);
		lbMonth.TextAlignment = UITextAlignment.Center;
		lbMonth.TextColor = UIColor.Black;
		lbMonth.Font = UIFont.BoldSystemFontOfSize (22);
		Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
		string[] monthNames = 
			System.Globalization.CultureInfo.CurrentCulture
				.DateTimeFormat.MonthGenitiveNames;
		
		lbMonth.Text = string.Format ("{0} {1}", monthNames[currentTime.Month], currentTime.Year);
		this.AddSubview (lbMonth);
		// draw the table
		UIView viewTable = new UIView();
		viewTable.BackgroundColor = UIColor.Clear;
		viewTable.Frame = new CoreGraphics.CGRect (0, _itemSize + 70, this.Bounds.Width, _itemSize * _numberRows);
		_buttons = new List<CalendarButton> ();
		for (int row = 0; row < _numberRows; row++) {
			for (int col = 0; col < _numberItemPerRow; col++) {
				CalendarButton btn = new CalendarButton ();
				btn.Frame = new CoreGraphics.CGRect (col * _itemSize, row * _itemSize, _itemSize, _itemSize);
				btn.BackgroundColor = UIColor.White; // default color;
				btn.Layer.BorderColor = UIColor.Black.CGColor;
				btn.Layer.BorderWidth = 1;
				btn.Layer.CornerRadius = _itemSize / 2;
				btn.Tag = 0;
				btn.SetTitleColor (UIColor.Black, UIControlState.Normal);
				_buttons.Add (btn);
				viewTable.AddSubview (btn);
			}
		}
		// get the first and last date of current month;
		DateTime nexMonth = currentTime.AddMonths(1);
		var startDate = new DateTime(nexMonth.Year, nexMonth.Month, 1);
		var endDate = startDate.AddMonths(1).AddDays(-1);
		int currentDateOfWeek = (int)startDate.Date.DayOfWeek;
		for (int i = 0; i < endDate.Day; i++) {
			CalendarButton btn = _buttons.ElementAt (currentDateOfWeek + i);
			btn.BackgroundColor = _labelColor;
			btn.SetTitle ((i + 1).ToString (), UIControlState.Normal);
			btn.ID = i + 1;
			btn.TouchUpInside += (object sender, EventArgs e) => {
				CalendarButton sd = (CalendarButton)sender;
				sd.Tag++;
				if (sd.Tag%3 == 0) {
					// gray
					sd.State = 0;
					sd.BackgroundColor = _labelColor;
				}else if(sd.Tag%3 == 1){
					// red
					sd.State = 1;
					sd.BackgroundColor = _oneTouchColor;
				}else{
					// green
					sd.State = 2;
					sd.BackgroundColor = _twoTouchColor;
				}
			};
		}
		this.AddSubview (viewTable);
	}
    }
