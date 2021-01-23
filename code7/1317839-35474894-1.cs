    class MainForm : Form {
        
        private void ShowChildFormModal() {
            
            ChildViewModel vm = new ChildViewModel();
            vm.CoordinatesList = ...
            vm.OtherData = ...
            
            ChildForm child = new ChildForm();
            child.LoadFromViewModel( vm );
            child.ShowDialog();
            child.SaveToViewModel( vm );
            
            SaveToDatabase( vm );
        }
    }
    class ChildViewModel { // this is a POCO
        public List<String> CoordinatesList;
        public Int32 OtherData;
    }
    class ChildForm : Form {
        
        public void LoadFromViewModel(ChildViewModel vm) {
            
            // save time and trouble by using the List as a datasource directly, or you can manually populate the combobox as well
            this.childUserControl.LoadFromViewModel( vm ); 
            
            this.someOtherControl.Value = vm.OtherData;
        }
        public void SaveToViewModel(ChildViewModel vm) {
            // completing this is an exercise for the reader
            // but basically copy values from the controls on the form into the `vm` instance
        }
    }
    
    class ChildUserControl : UserControl {
        
        public void LoadFromViewModel(ChildViewModel vm) {
            this.comboBox.DataSource = vm.CoordinatesList;
        }
    }
