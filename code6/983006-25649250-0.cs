            var table = new TableView {
				Intent = TableIntent.Settings,
				Root = new TableRoot("Table Name"),
				HasUnevenRows = true,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Transparent
			};
			var section = new TableSection ();
            
            //dataList in my case is the list of elements that populate each row
			dataList.ForEach (e => {
				//Add custom Cells to the TableSection
				section.Add(new ContactCardCell{BindingContext = e});
			});
			table.Root.Add (section);
