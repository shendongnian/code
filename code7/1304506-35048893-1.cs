    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    
    namespace WpfApplication
    {
        public class ViewModel : INotifyPropertyChanged
        {
    
            public event PropertyChangedEventHandler PropertyChanged;
            public ObservableCollection<Category> Categories { get; set; }
            public ICommand AddRowCommand { get; set; }
            public ViewModel()
            {
                Categories = new ObservableCollection<Category>()
               {
                 new Category(){ Id = 1, Name = "Cat1", Description = "This is Cat1 Desc"},
                 new Category(){ Id = 1, Name = "Cat2", Description = "This is Cat2 Desc"},
                 new Category(){ Id = 1, Name = "Cat3", Description = "This is Cat3 Desc"},
                 new Category(){ Id = 1, Name = "Cat4", Description = "This is Cat4 Desc"}
               };
    
                this.AddRowCommand = GlobalCommand<object>.GetInstance(ExecuteAddRowCommand, CanExecuteAddRowCommand);
            }
    
            private bool CanExecuteAddRowCommand(object parameter)
            {
                if (Categories.Count <= 15)
                    return true;
                return false;
            }
    
            private void ExecuteAddRowCommand(object parameter)
            {
                Categories.Add(new Category()
                {
                    Id = 1,
                    Name = "Cat"+(Categories.Count+1),
                    Description = "This is Cat" + (Categories.Count + 1) + " Desc"
                });
            }
           
        }
    }
