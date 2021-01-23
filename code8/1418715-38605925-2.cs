	public class PickerListCell : TextCell
	{
		
		public PickerListCell ()
		{
			var moreAction = new MenuItem { Text = App.Translate ("Edit") };
			moreAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
			moreAction.Clicked += async (sender, e) => {
				var mi = ((MenuItem)sender);
				var option = (PickerListPage.OptionListItem)mi.CommandParameter;
				var recId = new Guid (option.Value);
				// HERE I send a request to open a new page. This looks a 
                // bit crappy with a magic string. It will be replaced with a constant or enum
                MessagingCenter.Send<OptionListItem, Guid> (this, "PushPage", recId);
			};
			ContextActions.Add (moreAction);
		}
	}
