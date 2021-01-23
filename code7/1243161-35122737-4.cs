    	const int TextBoxMaxAllowedLines = 10;
		public static readonly DependencyProperty NotesTextProperty =
				DependencyProperty.Register(
					name: "NotesText",
					propertyType: typeof( String ),
					ownerType: typeof( SampleTextBoxEntryWindow ),
					typeMetadata: new PropertyMetadata(
						defaultValue: string.Empty,
						propertyChangedCallback: OnNotesTextPropertyChanged,
						coerceValueCallback: CoerceTextLineLimiter ) );
        public string NotesText
	    {
		    get { return (String)GetValue( NotesTextProperty ); }
		    set { SetValue( NotesTextProperty, value ); }
	    }
		private static void OnNotesTextPropertyChanged(DependencyObject source,
			DependencyPropertyChangedEventArgs e)
		{
			// Whatever you want to do when the text changes, like 
			// set flags to allow buttons to light up, etc.
		}
		private static object CoerceTextLineLimiter(DependencyObject d, object value)
		{
			string result = null;
			if (value != null)
			{
				string text = ((string)value);
				string[] lines = text.Split( '\n' );
				if (lines.Length <= TextBoxMaxAllowedLines)
					result = text;
				else
				{
					StringBuilder obj = new StringBuilder();
					for (int i = 0; i < TextBoxMaxAllowedLines; i++)
						obj.AppendLine( lines[i] );
					result = obj.ToString();
				}
			}
			return result;
		}
