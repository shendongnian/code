		class PickerDelegate : UIPickerViewDelegate
		{
			public override void Selected(UIPickerView pickerView, nint row, nint component)
			{
				base.Selected(pickerView, row, component);
				Console.WriteLine(row.ToString());
			}
		}
