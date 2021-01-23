	private void MyTextMethod(){
		defBlock.Text = arrayDef[ListView1.SelectedIndex][ListView2.SelectedIndex];  
	}
	private void ListView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {
         try{
		 
			MyTextMethod)();
		 }
		 catch(OutOfRangeException){ 
			// do something.
		 }
	}
