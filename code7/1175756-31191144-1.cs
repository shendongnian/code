    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Input;
    
    namespace WpfApplication
    {
        abstract class ObservableObject : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                var handler = this.PropertyChanged;
                if (handler != null)
                    handler(this, e);
            }
    
            protected void Set<T>(ref T field, T value, string propertyName)
            {
                if (!EqualityComparer<T>.Default.Equals(field, value))
                {
                    field = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
        sealed class DelegateCommand : ICommand
        {
            private readonly Action action;
    
            public DelegateCommand(Action action)
            {
                if (action == null)
                    throw new ArgumentNullException("action");
    
                this.action = action;
            }
    
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
    
            public void Execute()
            {
                this.action();
            }
    
            bool ICommand.CanExecute(object parameter)
            {
                return true;
            }
    
            void ICommand.Execute(object parameter)
            {
                this.Execute();
            }
        }
    
        class Person : ObservableObject
        {
            private string name, surname;
    
            public Person()
            {
            }
    
            public Person(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
            }
    
            public string Name
            {
                get { return this.name; }
                set { this.Set(ref this.name, value, "Name"); }
            }
    
            public string Surname
            {
                get { return this.surname; }
                set { this.Set(ref this.surname, value, "Surname"); }
            }
    
            public override string ToString()
            {
                return this.name + ' ' + this.surname;
            }
        }
    
        class MainWindowModel : ObservableObject
        {
            public ObservableCollection<Person> People { get; private set; }
    
            public SelectedItemCollection<Person> SelectedPeople { get; private set; }
    
            public DelegateCommand SelectAllCommand { get; private set; }
            public DelegateCommand UnselectAllCommand { get; private set; }
            public DelegateCommand SelectNextRangeCommand { get; private set; }
    
            public MainWindowModel()
            {
                this.People = new ObservableCollection<Person>(Enumerable.Range(1, 1000).Select(i => new Person("Name " + i, "Surname " + i)));
                this.SelectedPeople = new SelectedItemCollection<Person>();
                for (int i = 0; i < this.People.Count; i += 2)
                    this.SelectedPeople.Add(this.People[i]);
    
                this.SelectAllCommand = new DelegateCommand(() => this.SelectedPeople.Reset(this.People));
    
                this.UnselectAllCommand = new DelegateCommand(() => this.SelectedPeople.Clear());
    
                this.SelectNextRangeCommand = new DelegateCommand(() =>
                {
                    var index = this.SelectedPeople.Count > 0 ? this.People.IndexOf(this.SelectedPeople[this.SelectedPeople.Count - 1]) + 1 : 0;
    
                    int count = 10;
    
                    this.SelectedPeople.Reset(Enumerable.Range(index, count).Where(i => i < this.People.Count).Select(i => this.People[i]));
                });
    
                this.SelectedPeople.CollectionChanged += this.OnSelectedPeopleCollectionChanged;
            }
    
            private void OnSelectedPeopleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                Debug.WriteLine("Action = {0}, NewItems.Count = {1}, NewStartingIndex = {2}, OldItems.Count = {3}, OldStartingIndex = {4}, Total.Count = {5}", e.Action, e.NewItems != null ? e.NewItems.Count : 0, e.NewStartingIndex, e.OldItems != null ? e.OldItems.Count : 0, e.OldStartingIndex, this.SelectedPeople.Count);
            }
        }
    
        class SelectedItemCollection<T> : ObservableCollection<T>
        {
            public void Reset(IEnumerable<T> items)
            {
                int oldCount = this.Count;
    
                this.Items.Clear();
                foreach (var item in items)
                    this.Items.Add(item);
    
                if (!(oldCount == 0 && this.Count == 0))
                {
                    this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    
                    if (this.Count != oldCount)
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
                }
            }
        }
    }
