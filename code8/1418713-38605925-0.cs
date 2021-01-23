	public class PickerListCell : TextCell
	{
		// HERE I added a bindable property
		public static readonly BindableProperty EditCommandProperty = BindableProperty.Create ("EditCommand", typeof (ICommand), typeof (PickerListCell), null);
		public ICommand EditCommand {
			get { return (ICommand)GetValue (EditCommandProperty); }
			set { SetValue (EditCommandProperty, value); }
		}
		public PickerListCell ()
		{
			var moreAction = new MenuItem { Text = App.Translate ("Edit") };
			moreAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
			moreAction.Clicked += async (sender, e) => {
				var mi = ((MenuItem)sender);
				var option = (PickerListPage.OptionListItem)mi.CommandParameter;
				var recId = new Guid (option.Value);
				// HERE I execute the binded property
				EditCommand.Execute (recId);
			};
			ContextActions.Add (moreAction);
		}
	}
