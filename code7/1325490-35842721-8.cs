    public class YourMVVMClass
    {
            public YourMVVMClass()
            {
			   SelectedRptRow = null;
			   ReportsTable = new List<IReports>() 
			   {
				   new Students() { Name = "Student 1" },
				   new Students() { Name = "Student 2" },
				   new Classes() { ClassName="CS 101", StudentName = "Student 3" },
				   new Cars() { CarType = "Truck", Mileage=12345, StudentName = "Student 4" }
			   };
            }
            // This get/set for binding your data grid to
    		public List<IReports> ReportsTable { get; set; }
            // This for the Selected Row the data grid binds to
    		public IReports SelectedRptRow { get; set; }
    
            // This for a user double-clicking to select an entry from
    		private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    		{
    			// Now, you can look directly at the SelectedRptRow
    			// as in the data-grid binding declaration.
    			if (SelectedRptRow is Classes)
    				MessageBox.Show("User selected a class item");
    			else if( SelectedRptRow is Cars)
    				MessageBox.Show("User selected a car item");
    			else if( SelectedRptRow is Students)
    				MessageBox.Show("User selected a student item");
    			else
    				MessageBox.Show("No entry selected");
    		}
    }
