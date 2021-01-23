    public class TimesViewModel: INotifyPropertyChanged
    {
        //notifying property that is bound to ItemsSource in the first Combobox
        public ObservableCollection<Department> Departments{ get... }
        
        //total list of job codes
        public List<string> JobCodes{ get...}
        //This is the Department that's bound to SelectedItem in the first ComboBox
        public Department Department
        {
            get
            {
                return department;
            }
            set
            {
                //standard notify like all your other bound properties
                if (department!= value)
                {
                    department= value;
                    //when this changes, our selection has changed, so update the second list's ItemsSource
                    DepartmentOnlyJobCodes = JobCodes.Where(jobCode => jobCode.StartsWith(Department.DepartmentCode)).ToList();
                    //we can also do more complex operations for example, lets clear the JobCode!
                    JobCode = "";
                    NotifyPropertyChanged("SelectedKey");
                }
            }
        }
        //an "intermediatary" Property that's bound to the second Combobox, changes with the first's selection
        public ObservableCollection<string> DepartmentOnlyJobCodes{ get ... }
        public string JobCode {get...}
    }
