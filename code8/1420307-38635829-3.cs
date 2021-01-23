    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.CommandWpf;
    
    namespace StackOverFlow1.ViewModel
    {
       
        public class MainViewModel : ViewModelBase
        {
           
            public MainViewModel()
            {
             NextCommand=new RelayCommand<int>(OnNext,CanNext);
             PreviousCommand=new RelayCommand<int>(OnPrevious,CanPrevious);
                SelectedIndex = 0;
    
                foreach (var student in GetStudent())
                {
                    _students.Add(student);
                }
            }
    
            public ICommand NextCommand { get; set; }
            public ICommand PreviousCommand { get; set; }
            private int _selectedIndex;
    
    
            private List<Student> GetStudent()
            {
                return new List<Student>()
                {
                    new Student {Id = 0,Name = "Kwame0"},
                     new Student {Id = 0,Name = "Kwame1"},
                     new Student {Id = 0,Name = "Kwame2"},
                     new Student {Id = 0,Name = "Kwame3"},
                      new Student {Id = 0,Name = "Kwame4"},
                     new Student {Id = 0,Name = "Kwame5"},
                     new Student {Id = 0,Name = "Kwame6"},
                     new Student {Id = 0,Name = "Kwame7"},
                       new Student {Id = 0,Name = "Kwame8"},
                     new Student {Id = 0,Name = "Kwame9"},
                     new Student {Id = 0,Name = "Kwame10"},
                     new Student {Id = 0,Name = "Kwame11"},
                      new Student {Id = 0,Name = "Kwame12"},
                     new Student {Id = 0,Name = "Kwame13"},
                     new Student {Id = 0,Name = "Kwame14"},
                     new Student {Id = 0,Name = "Kwame15"},
                };
            }
            public int SelectedIndex
            {
                get { return _selectedIndex; }
                set { _selectedIndex = value;RaisePropertyChanged(()=>SelectedIndex); }
            }
    
    
            private ObservableCollection<Student> _students=new ObservableCollection<Student>();
    
            public ObservableCollection<Student> Students
            {
                get { return _students; }
                set { _students = value; }
            }
    
    
            private void OnNext(int index)
            {
                if (SelectedIndex != Students.Count)
                    SelectedIndex += 1;
                else
                {
                    SelectedIndex = 0;
                }
            }
    
            private bool CanNext(int indext)
            {
                return SelectedIndex != Students.Count;
            }
    
            private void OnPrevious(int index)
            {
                if (SelectedIndex != 0)
                    SelectedIndex -= 1;
                else
                {
                    SelectedIndex = Students.Count;
                }
            }
    
            private bool CanPrevious(int index)
            {
                return SelectedIndex != 0;
            }
    
        }
    
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
    
            public override string ToString()
            {
                return $"{Id}-{Name}";
            }
        }
    }
