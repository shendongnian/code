    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> _personList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            _personList = new ObservableCollection<Person>();
            _personList.Add(new Person() { Name = "Person1" });
            _personList.Add(new Person() { Name = "Person2" });
            _personList.Add(new Person() { Name = "Person3" });
            _personList.Add(new Person() { Name = "Person4" });
            _personList.Add(new Person() { Name = "Person5" });
            _personList.Add(new Person() { Name = "Person6" });
            MyListView.DataContext = this._personList;
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MyListView.SelectedItems.Cast<object>().ToList())
            {
                _personList.Remove((Person)item);
            }
        }
    }
    public class Person
    {
        public string Name { get; set; }
    }
    <Window x:Class="ListView.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:ListView"
        mc:Ignorable="d"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <StackPanel>
        <ListView Background="DarkCyan" Foreground="White" Name="MyListView"
          ItemsSource="{Binding}" Height="200" DisplayMemberPath="Name"
          SelectionMode="Multiple"/>
        <Button Name="RemoveButton"
        Click="RemoveButton_Click" Height="100" Width="100" />
        </StackPanel>
    </Grid>
