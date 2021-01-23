        public class Bike:INotifyPropertyChanged
            {
                public string number { get; set; }
                public string endtime { get; set; }
                string _foramtedtime;
                public string FormattedEndTime
                {
                    get
                    {
                        return _foramtedtime;
                    }
                    set
                    {
        
                        if(value!=_foramtedtime)
                        {
                            _foramtedtime = value;
                            OnPropertyChanged("FormattedEndTime");
                        }
                    }
                    }
        
                void OnPropertyChanged(string propertyName)
                {
                    // the new Null-conditional Operators are thread-safe:
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }
        
        
                public TimeSpan EndTimeinTimeSpan;
        
                public event PropertyChangedEventHandler PropertyChanged;
        
                public Bike(string numb,string endtim)
                {
                    number = numb;
                    endtime = endtim;
                    var seconds = int.Parse(endtime);
                    FormattedEndTime=  string.Format("{0:00}:{1:00}",(seconds / 60) % 60, seconds % 60);
                    EndTimeinTimeSpan = TimeSpan.Parse(string.Format("{0:00}:{1:00}:{2:00}", seconds / 3600, (seconds / 60) % 60, seconds % 60));
                }
            }
        public sealed partial class MainPage : Page
            {
                   VM = new TestViewModel();
                DataContext = VM;
                this.Loaded += MainPage_Loaded;
                    DispatcherTimer timertostoop;
                    DispatcherTimer timer;
                   public MainPage()
                   {
                           TimeSpan time =( DataContext as TestViewModel).Bikes.Max(x => x.EndTimeinTimeSpan);
                    timertostoop   = new DispatcherTimer() { Interval = time };
                    timertostoop.Tick += Timertostoop_Tick;
                    timer = new DispatcherTimer() { Interval =TimeSpan.FromSeconds(1) };
                    timer.Tick += Timer_Tick;
                   }
                     private void Timertostoop_Tick(object sender, object e)
                {
                    if (timer != null && timer.IsEnabled)
                        timer.Stop();
                    timertostoop.Stop();
                }
        
                private async void MainPage_Loaded(object sender, RoutedEventArgs e)
                {
                 
                    timer.Start();
                }
                private void Timer_Tick(object sender, object e)
                {
        
                  foreach(var bike in VM.Bikes)
                    {
                        if(bike.EndTimeinTimeSpan>TimeSpan.FromSeconds(0))
                        {
                            bike.EndTimeinTimeSpan = bike.EndTimeinTimeSpan - TimeSpan.FromSeconds(1);
                            bike.FormattedEndTime = string.Format("{0:00}:{1}", (bike.EndTimeinTimeSpan.TotalSeconds/ 60) % 60, bike.EndTimeinTimeSpan.Seconds);
                        }
                    }
                }
        
            }
      <ListView x:Name="BikesList" ItemsSource="{Binding Bikes}">
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <Grid Width="360" VerticalAlignment="Center">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition/>
                                <ColumnDefinition/>
                            </Grid.ColumnDefinitions>
    
                            <TextBlock Grid.Column="0" Text="{Binding number}"/>
    
                            <TextBlock Grid.Column="1" Text="{Binding FormattedEndTime}"/> 
    
                        </Grid>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
