    public class ComboViewModel : INotifyPropertyChanged {
       private List<string> tables;
       public List<string> Tables {
          get { return tables; }
          set {
             tables = value;
             OnPropertyChanged("Tables");
          }
       }
    
       private string selectedTable;
       public string SelectedTable {
          get { return selectedTable; }
          set {
				selectedTable = value;
				// react to user selection
			}
       }
       public event PropertyChangedEventHandler PropertyChanged;
       private void RaisePropertyChanged(string propertyName) {
          if (this.PropertyChanged != null)
             this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
       }
    }
    
    public class FileDialogViewModel {
    	ComboViewModel ComboVM {
    		get { /* return ComboViewModel instance */ }
    	}
    
    	void UpdateTables(string mdbDir) {
    		ComboVM.Tables = TablesList(mdbDir);
    	}
    }
