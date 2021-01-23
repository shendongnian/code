    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Learn.MVVM.Example.Common.Commands;
    using Learn.MVVM.Example.Models;
    using Learn.MVVM.Example.Models.Business;
    using Learn.MVVM.Example.Views;
     
    namespace Learn.MVVM.Example.ViewModels
    {
        public class PersonsViewModel<TViewType> : IViewModel where TViewType : IView, new()
        {
            private readonly IView _view;
            private readonly PersonModel _model;
     
            public ObservableCollection<Person> Persons { get; set; }
            public RelayCommand OkCommand { get; private set; }
     
            private string _str;
            
            public PersonsViewModel()
            {
                this._view = new TViewType();
                this._model = new PersonModel();
                this.Persons = new ObservableCollection<Person>(this._model.GetPersons());
                this.OkCommand = new RelayCommand(o => this.OKRun());
     
                _str = "Кнопка";
     
     
                this._view.SetDataContext(this);
                this._view.ShowView();
     
              
            }
     
     
            public string Str
            {
                get { return _str; }
                set
                {
                    if (_str == value)
                        return;
                    _str = value;
                    OnPropertyChanged("Str");
     
                }
     
     
            }
     
     
            public event PropertyChangedEventHandler PropertyChanged;
     
            //[NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
     
     
            private void OKRun()
            {
                _str = "Change";
            }
        }
    }
