    using System.ComponentModel;
    
    namespace YourApp.ViewModels
    {
        public class GeneralViewModel
        {
            private HaveLoginData _regionData;
            public HaveLoginData RegionData
            {
                get { return _regionData; }
                set
                {
                    _regionData = value;
                    _regionData.PropertyChanged += _regionData_PropertyChanged;
                }
            }
    
            private void _regionData_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "Login")
                {
                    // do the second view model login logic
                }
            }
        }
    }
