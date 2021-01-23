    	//init
		private void Init3_CodedComponents(){
			myLineDropBox.CB_Add_Item("1");
			myLineDropBox.CB_Add_Item("2");
			...
			myLineDropBox.CB_Select_Item("4");
			...
			AddHandler(FileLineDropBox.ValueChangedEvent, new RoutedEventHandler(FileLineComboBox_CntChangedEvent));
		}
		
		// EventHandler
		private void FileLineComboBox_CntChangedEvent(object sender, RoutedEventArgs e){
			...
			int.TryParse(myLineDropBox.Value, out maxId);
			...
		}
