    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Q9
    {
        public class ViewModel : System.ComponentModel.INotifyPropertyChanged
        {
            private ShowCarInformationCommand mShowCarInformationCommand;
    
            public ShowCarInformationCommand ShowCarInformationCommand
            {
                get
                {
                    if (mShowCarInformationCommand == null)
                    {
                        mShowCarInformationCommand = new ShowCarInformationCommand(this);
                    }
                    return mShowCarInformationCommand;
                }
                set
                {
                    mShowCarInformationCommand = value;
                }
            }
            private System.Collections.ObjectModel.ObservableCollection<Car> mCars;
    
            public System.Collections.ObjectModel.ObservableCollection<Car> Cars
            {
                get
                {
                    if (mCars == null)
                    {
                        mCars = new System.Collections.ObjectModel.ObservableCollection<Car>();
                    }
                    return mCars;
                }
                set
                {
                    mCars = value;
                }
            }
            private Car mSelectedCar;
    
            public Car SelectedCar
            {
                get
                {
                    return mSelectedCar;
                }
                set
                {
                    mSelectedCar = value;
                    OnPropertyChanged("SelectedCar");
                }
            }
    
            public ViewModel()
            {
                Cars.Add(new Car() { Name = "Honda" });
                Cars.Add(new Car() { Name = "Ferrari" });
                Cars.Add(new Car() { Name = "Bentley" });
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
