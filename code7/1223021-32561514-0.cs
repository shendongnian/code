    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Score : ViewModelBase
    {
        public int Value { get; set; }
    }
    public class Student : ViewModelBase
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public DateTime Dob { get; private set; }
        public ObservableCollection<Score> Scores { get; set; }
        public Student(string name, string address, DateTime dob)
        {
            Name = name;
            Address = address;
            Dob = dob;
            Scores = new ObservableCollection<Score>();
        }
    } 
    public class StudentViewModel : ViewModelBase
    {
        public ObservableCollection<Student> Students { get; private set; }
        public StudentViewModel()
        {
            Students = new ObservableCollection<Student>
            {
                new Student("Student A", "A Address", DateTime.Now)
                {
                    Scores = new ObservableCollection<Score>
                    {
                        new Score { Value = 80 }, 
                        new Score { Value = 85 }, 
                        new Score { Value = 90 }, 
                    }
                },
                new Student("Student B", "B Address", DateTime.Now)
                {
                    Scores = new ObservableCollection<Score>
                    {
                        new Score { Value = 70 }, 
                        new Score { Value = 75 }, 
                        new Score { Value = 60 }, 
                    }
                }
            };
        }
        private Student _selectedStudent;        
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set 
            {
                _selectedStudent = value;
                OnPropertyChanged("SelectedStudentScores");
            }
        }
        public ObservableCollection<Score> SelectedStudentScores
        {
            get
            {
                if (_selectedStudent == null) return null;
                return _selectedStudent.Scores;
            }
        }
        public Score SelectedScore { get; set; }
    }
    <Window x:Class="StudentScoreWpfProj.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:studentScoreWpfProj="clr-namespace:StudentScoreWpfProj"
        mc:Ignorable="d"
        d:DataContext="{d:DesignInstance Type=studentScoreWpfProj:StudentViewModel,IsDesignTimeCreatable=True}"        
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>
        
        <DataGrid ItemsSource="{Binding Students}" AutoGenerateColumns="False"
                  SelectedItem="{Binding SelectedStudent}">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Name" Binding="{Binding Name, Mode=OneWay}" />
                <DataGridTextColumn Header="Address" Binding="{Binding Address, Mode=OneWay}" />
                <DataGridTextColumn Header="Birth" Binding="{Binding Dob, Mode=OneWay, StringFormat={}{0:MM/dd/yyyy}}" />
            </DataGrid.Columns>
        </DataGrid>
        <DataGrid Grid.Row="1" ItemsSource="{Binding SelectedStudentScores}"
                  SelectedItem="{Binding SelectedScore}">
        </DataGrid>
    </Grid>
