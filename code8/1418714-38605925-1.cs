		public class OptionListItem
		{
			public string Caption { get; set; }
			public string Value { get; set; }
			// HERE I added a new property to bind with the new Cell property
			public ICommand OnEditAction {
				get {
					return new Command ((parm) => {
						var recId = (Guid)parm;
						// HERE I send a request to open a new page. This looks a 
						// bit crappy with a magic string. It will be replaced with a constant or enum
						MessagingCenter.Send<OptionListItem, Guid> (this, "PushPage", recId);
					});
				}
			}
		}
