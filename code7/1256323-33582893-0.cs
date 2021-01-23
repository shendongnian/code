	/// <summary>
	/// DatePicker der null Werte erlaubt
	/// </summary>
	public class CustomDatePicker : DatePicker
	{
		/// <summary>
		/// PropertyName für die <c>NullableDate</c> Property
		/// </summary>
		public const string NullableDatePropertyName = "NullableDate";
		/// <summary>
		/// Die BinableProperty
		/// </summary>
		public static readonly BindableProperty NullableDateProperty = BindableProperty.Create<CustomDatePicker, DateTime?>(i => i.NullableDate, null, BindingMode.TwoWay, null, NullableDateChanged);
		/// <summary>
		/// Datumswert welches null Werte akzeptiert
		/// </summary>
		public DateTime? NullableDate
		{
			get
			{
				return (DateTime?)this.GetValue(NullableDateProperty);
			}
			set
			{
				this.SetValue(NullableDateProperty, value);
			}
		}
		/// <summary>
		/// Der Name der <c>NullText</c> Property
		/// </summary>
		public const string NullTextPropertyName = "NullText";
		/// <summary>
		/// Die BindableProperty
		/// </summary>
		public static readonly BindableProperty NullTextProperty = BindableProperty.Create<CustomDatePicker, string>(i => i.NullText, default(string), BindingMode.TwoWay);
		/// <summary>
		/// Der Text der angezeigt wird wenn <c>NullableDate</c> keinen Wert hat
		/// </summary>
		public string NullText
		{
			get
			{
				return (string)this.GetValue(NullTextProperty);
			}
			set
			{
				this.SetValue(NullTextProperty, value);
			}
		}
		/// <summary>
		/// Der Name der <c>DisplayBorder</c> Property
		/// </summary>
		public const string DisplayBorderPropertyName = "DisplayBorder";
		/// <summary>
		/// Die BindableProperty
		/// </summary>
		public static readonly BindableProperty DisplayBorderProperty = BindableProperty.Create<CustomDatePicker, bool>(i => i.DisplayBorder, default(bool), BindingMode.TwoWay);
		/// <summary>
		/// Gibt an ob eine Umrandung angezeigt werden soll oder nicht
		/// </summary>
		public bool DisplayBorder
		{
			get
			{
				return (bool)this.GetValue(DisplayBorderProperty);
			}
			set
			{
				this.SetValue(DisplayBorderProperty, value);
			}
		}
		/// <summary>
		/// Erstellt eine neue Instanz von <c>CustomDatePicker</c>
		/// </summary>
		public CustomDatePicker()
		{
			this.DateSelected += CustomDatePicker_DateSelected;
			this.Format = "dd.MM.yyyy";
		}
		/// <summary>
		/// Wird gefeuert wenn ein neues Datum selektiert wurde
		/// </summary>
		/// <param name="sender">Der Sender</param>
		/// <param name="e">Event Argumente</param>
		void CustomDatePicker_DateSelected(object sender, DateChangedEventArgs e)
		{
			this.NullableDate = new DateTime(
				e.NewDate.Year, 
				e.NewDate.Month, 
				e.NewDate.Day, 
				this.NullableDate.HasValue ? this.NullableDate.Value.Hour : 0,
				this.NullableDate.HasValue ? this.NullableDate.Value.Minute : 0,
				this.NullableDate.HasValue ? this.NullableDate.Value.Second : 0);
		}
		/// <summary>
		/// Gefeuert wenn sich <c>NullableDate</c> ändert
		/// </summary>
		/// <param name="obj">Der Sender</param>
		/// <param name="oldValue">Der alte Wert</param>
		/// <param name="newValue">Der neue Wert</param>
		private static void NullableDateChanged(BindableObject obj, DateTime? oldValue, DateTime? newValue)
		{
			var customDatePicker = obj as CustomDatePicker;
			if (customDatePicker != null)
			{
				if (newValue.HasValue)
				{
					customDatePicker.Date = newValue.Value;
				}
			}
		}
	}
