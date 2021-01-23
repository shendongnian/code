    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" 
            DataContext="{Binding RelativeSource={RelativeSource self}}" 
            Title="SQL Formatter" Height="600" Width="800">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            <ScrollViewer Grid.Row="0" HorizontalScrollBarVisibility="Auto" VerticalScrollBarVisibility="Auto">
                <TextBox  AcceptsReturn="True" AcceptsTab="True"  
                          Text="{Binding Path=Input, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
            </ScrollViewer>
            <ScrollViewer Grid.Row="1" HorizontalScrollBarVisibility="Auto" VerticalScrollBarVisibility="Auto">
                <TextBox  Text="{Binding Path=Output, Mode=OneWay}"/>
            </ScrollViewer>
        </Grid>
    </Window>
    
    using System.ComponentModel;
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
            public MainWindow()
            {
                InitializeComponent();
            }
            private string input = "input raw TSQL here";
            public string Input
            {
                set
                {
                    if (input == value) return;
                    input = value;
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("string query = ");
                    bool first = true;
                    foreach(string line in input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
                    {
                        if (string.IsNullOrEmpty(line))
                            continue;
                        if (first)
                            first = false;
                        else
                            sb.AppendLine(" + Environment.NewLine + ");
                        sb.Append("\t\t\t\t\t\t\"" + line + " \"");
                    }
                    sb.Append(";");
                    Output = sb.ToString();
                }
                get { return input; }
            }
            private string output = string.Empty;
            public string Output
            {
                set
                {
                    if (output == value) return;
                    output = value;
                    NotifyPropertyChanged("Output");
                }
                get { return output; }
            }
        }
    }
