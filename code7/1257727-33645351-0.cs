    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using Learn.MVVM.Example.Annotations;
     
    namespace Learn.MVVM.Example.Models.Business
    {
        public class Person : INotifyPropertyChanged
        {
            #region Fields
     
            private string _firstName;
            private string _middleName;
            private string _lastName;
            private DateTime _dateOfBirth;
            private Gender _gender;
     
            #endregion Fields
     
            #region Properties
     
            public string FirstName
            {
                get { return _firstName; }
                set
                {
                    if (value == _firstName) return;
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
            public string MiddleName
            {
                get { return _middleName; }
                set
                {
                    if (value == _middleName) return;
                    _middleName = value;
                    OnPropertyChanged();
                }
            }
            public string LastName
            {
                get { return _lastName; }
                set
                {
                    if (value == _lastName) return;
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
            public DateTime DateOfBirth
            {
                get { return _dateOfBirth; }
                set
                {
                    if (value.Equals(_dateOfBirth)) return;
                    _dateOfBirth = value;
                    OnPropertyChanged();
                }
            }
            public Gender Gender
            {
                get { return _gender; }
                set
                {
                    if (value == _gender) return;
                    _gender = value;
                    OnPropertyChanged();
                }
            }
     
            #endregion Properties
     
            #region Constructors
     
            public Person()
            {
     
            }
     
            public Person(string firstName, string middleName, string lastName, DateTime dateOfBirth, Gender gender)
            {
                FirstName = firstName;
                MiddleName = middleName;
                LastName = lastName;
                DateOfBirth = dateOfBirth;
                Gender = gender;
            }
     
            #endregion Constructors
            
            #region INotifyPropertyChanged
     
            public event PropertyChangedEventHandler PropertyChanged;
     
            //[NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
     
            #endregion INotifyPropertyChanged
     
        }
     
        public enum Gender
        {
            Male,
            Female
        }
    }
