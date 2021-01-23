    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    
    public class NotifyChangements : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void NotifyPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
    
            public bool NotifyPropertyChanged<T>(ref T variable, T valeur, [CallerMemberName] string property = null)
            {
                if (object.Equals(variable, valeur)) return false;
                variable = valeur;
                NotifyPropertyChanged(property);
                return (true);
            }
        }
