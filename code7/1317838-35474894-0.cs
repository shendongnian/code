    class MainForm : Form {
        
        private void ShowChildFormModal() {
            
            ChildViewModel vm = new ChildViewModel();
            vm.CoordinatesList = ...
            vm.OtherData = ...
            
            ChildForm child = new ChildForm();
            child.LoadFromViewModel( vm );
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
    }
    
    class ChildUserControl : UserControl {
        
        public void LoadFromViewModel(ChildViewModel vm) {
            this.comboBox.DataSource = vm.CoordinatesList;
        }
    }
