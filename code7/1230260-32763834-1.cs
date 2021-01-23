    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<TblTransaction> TransList { get; private set; }
        public DispatcherTimer DispatchTimer = new DispatcherTimer();        
        public MainViewModel()
        {
            var model = new ObservableCollection<TblTransaction>();
            for (int i = 0; i < 5; i++)
            {
                model.Add(new TblTransaction { CaseRefNo = i.ToString(), IncValue = i, LongTime = DateTime.Now, SubjMatr = i.ToString() });
                if (i == 3)
                    model[i].IsSelected = true;
            }               
            DispatchTimer.Interval = TimeSpan.FromMilliseconds(200); 
            DispatchTimer.Tick += dispatchTimer_Tick;
            TransList = model;
            DispatchTimer.Start();
        }
        private void dispatchTimer_Tick(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }       
        public void UpdateDataGrid()
        {           
            var ran = new Random();
            foreach (var tran in TransList)
                tran.IncValue = ran.Next(0, 100);
        }        
    }
    public class TblTransaction : ViewModelBase
    {
        private string caseRefNo;
        private string subjMatr;
        private int incValue;
        private DateTime? longTime;
        private bool isSelected;
        public DelegateCommand<object> CheckCommand { get; set; }
        public TblTransaction()
        {
            CheckCommand = new DelegateCommand<object>(CheckBoxChecker, (p) => true);
        }
        private void CheckBoxChecker(object args)
        {
            //Should Work Here
            // Totally not coming to this function
            //CheckBox chk = (CheckBox)args;
            //string thichintae = chk.Name;
            Console.WriteLine(args);
        }
        public string CaseRefNo
        {
            get { return caseRefNo; }
            set
            {
                caseRefNo = value;
                OnPropertyChanged();
            }
        }
        public string SubjMatr
        {
            get { return subjMatr; }
            set
            {
                subjMatr = value;
                OnPropertyChanged();
            }
        }
        public int IncValue
        {
            get { return incValue; }
            set
            {
                incValue = value;
                OnPropertyChanged();
            }
        }
        public DateTime? LongTime
        {
            get { return longTime; }
            set
            {
                longTime = value;
                OnPropertyChanged();
            }
        }
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged();
            }
        }
    }
    <Window x:Class="WpfTestProj.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
        xmlns:local="clr-namespace:WpfTestProj"
        xmlns:interact="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity"
        mc:Ignorable="d" 
        d:DataContext="{d:DesignInstance Type=local:MainViewModel, IsDesignTimeCreatable=False}"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <DataGrid HorizontalAlignment="Left" ItemsSource="{Binding TransList}" AutoGenerateColumns="False" Margin="10,62,0,0" VerticalAlignment="Top" Height="497" Width="762">
            <DataGrid.Columns>
                <DataGridTextColumn Header="caseRefNo" Binding="{Binding CaseRefNo}" />
                <DataGridTextColumn Header="subjMatr" Binding="{Binding SubjMatr}" />
                <DataGridTextColumn Header="Download %" Binding="{Binding IncValue}" />
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <CheckBox
                                Content="Please Select" IsChecked="{Binding Path=IsSelected, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">
                                <interact:Interaction.Triggers>
                                    <interact:EventTrigger EventName="Checked">
                                        <interact:InvokeCommandAction CommandParameter="{Binding Path=CaseRefNo}" Command="{Binding Path=CheckCommand}" />
                                    </interact:EventTrigger>
                                </interact:Interaction.Triggers>
                            </CheckBox>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Label Content="{Binding IncValue, UpdateSourceTrigger=PropertyChanged}" Background="Red" Foreground="White" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
        <Button Content="Button" HorizontalAlignment="Left" Margin="672,20,0,0" VerticalAlignment="Top" Width="75"/>
    </Grid>
