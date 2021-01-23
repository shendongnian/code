    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Q9
    {
        public class Car
        {
    
            
            private System.String mName;
    
            public System.String Name
            {
                get { return mName; }
                set { mName = value; }
            }
    
        }
        public class ShowCarInformationCommand : System.Windows.Input.ICommand
        {
            public event EventHandler CanExecuteChanged;
    
            public bool CanExecute(object parameter)
            {
                return true;
            }
            ViewModel Model;
            public ShowCarInformationCommand(ViewModel model)
            {
                Model = model;
            }
            public void Execute(object parameter)
            {
                System.Windows.MessageBox.Show(Model.SelectedCar.Name);
            }
        }
    }
