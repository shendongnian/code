    <Window x:Class="BindDictionary.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            DataContext="{Binding RelativeSource={RelativeSource self}}"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <ListBox ItemsSource="{Binding Path=DLBS, Mode=OneWay}"
                     DisplayMemberPath="Key"
                     SelectedValuePath="Key" 
                     SelectedValue="{Binding Path=DLBSkey}"/>   
        </Grid>
    </Window>
    
    using System.ComponentModel;
    namespace BindDictionary
    {
        public partial class MainWindow : Window , INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
            private byte? dlBSkey = 1;
            private Dictionary<byte, string> dlBS = new Dictionary<byte, string>() { { 1, "one" }, { 2, "two" }, { 5, "five" } };      
            public MainWindow()
            {
                InitializeComponent();
            }
            public Dictionary<byte, string> DLBS { get { return dlBS; } }
            public byte? DLBSkey
            {
                get { return dlBSkey; }
                set
                {
                    if (dlBSkey == value) return;
                    dlBSkey = value;
                    NotifyPropertyChanged("DLBSkey");
                }
            }
    
        }
    }
