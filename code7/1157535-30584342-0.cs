	/// <summary>
	/// Attached properties for use with combo boxes
	/// </summary>
	public static class ComboBoxBehaviors
	{
		private static bool sInSelectionChange;
		/// <summary>
		/// Whether the combo box should commit changes to its Text property when the Enter key is pressed
		/// </summary>
		public static readonly DependencyProperty CommitOnEnterProperty = DependencyProperty.RegisterAttached("CommitOnEnter", typeof(bool), typeof(ComboBoxBehaviors),
			new PropertyMetadata(false, OnCommitOnEnterChanged));
		/// <summary>
		/// Returns the value of the CommitOnEnter property for the specified ComboBox
		/// </summary>
		public static bool GetCommitOnEnter(ComboBox control)
		{
			return (bool)control.GetValue(CommitOnEnterProperty);
		}
		/// <summary>
		/// Sets the value of the CommitOnEnterProperty for the specified ComboBox
		/// </summary>
		public static void SetCommitOnEnter(ComboBox control, bool value)
		{
			control.SetValue(CommitOnEnterProperty, value);
		}
		/// <summary>
		/// Called when the value of the CommitOnEnter property changes for a given ComboBox
		/// </summary>
		private static void OnCommitOnEnterChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			ComboBox control = sender as ComboBox;
			if (control != null)
			{
				if ((bool)e.OldValue)
				{
					control.KeyUp -= ComboBox_KeyUp;
					control.SelectionChanged -= ComboBox_SelectionChanged;
				}
				if ((bool)e.NewValue)
				{
					control.KeyUp += ComboBox_KeyUp;
					control.SelectionChanged += ComboBox_SelectionChanged;
				}
			}
		}
		/// <summary>
		/// Handler for the KeyUp event attached to a ComboBox that has CommitOnEnter set to true
		/// </summary>
		private static void ComboBox_KeyUp(object sender, KeyEventArgs e)
		{
			ComboBox control = sender as ComboBox;
			if (control != null && e.Key == Key.Enter)
			{
				BindingExpression expression = control.GetBindingExpression(ComboBox.TextProperty);
				if (expression != null)
				{
					expression.UpdateSource();
				}
				e.Handled = true;
			}
		}
		/// <summary>
		/// Handler for the SelectionChanged event attached to a ComboBox that has CommitOnEnter set to true
		/// </summary>
		private static void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (!sInSelectionChange)
			{
				var descriptor = DependencyPropertyDescriptor.FromProperty(ComboBox.TextProperty, typeof(ComboBox));
				descriptor.AddValueChanged(sender, ComboBox_TextChanged);
				sInSelectionChange = true;
			}
		}
		/// <summary>
		/// Handler for the Text property changing as a result of selection changing in a ComboBox that has CommitOnEnter set to true
		/// </summary>
		private static void ComboBox_TextChanged(object sender, EventArgs e)
		{
			var descriptor = DependencyPropertyDescriptor.FromProperty(ComboBox.TextProperty, typeof(ComboBox));
			descriptor.RemoveValueChanged(sender, ComboBox_TextChanged);
			ComboBox control = sender as ComboBox;
			if (control != null && sInSelectionChange)
			{
				sInSelectionChange = false;
				if (control.IsDropDownOpen)
				{
					BindingExpression expression = control.GetBindingExpression(ComboBox.TextProperty);
					if (expression != null)
					{
						expression.UpdateSource();
					}
				}
			}
		}
	}
