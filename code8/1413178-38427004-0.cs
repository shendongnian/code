    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Episodes> episodes = new List<Episodes>();
            for (int i = 0; i < 10; i++)
            {
                episodes.Add(new Episodes()
                {
                    Season = i.ToString(),
                    Episode = (i + 2).ToString(),
                    Download = true,
                    Watched = true,
                });
            }
            EpisodesList.ItemsSource = episodes;
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            Episodes epi = chk.DataContext as Episodes;
            var season = epi.Season;
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            Episodes epi = chk.DataContext as Episodes;
            var season = epi.Season;
        }
    }
     <ListView Margin="0,0,0,0" Name="EpisodesList">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="Season" Width="Auto">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <StackPanel>
                                    <TextBlock Text="{Binding Season}"/>
                                </StackPanel>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Header="Episode" Width="50">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <StackPanel>
                                    <TextBlock Text="{Binding Episode}"/>
                                </StackPanel>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Header="Assitido" Width="50">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <StackPanel>
                                    <CheckBox IsChecked="{Binding Watched}" Checked="CheckBox_Checked" Unchecked="CheckBox_Unchecked" />
                                </StackPanel>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Header="Baixar" Width="50">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <StackPanel>
                                    <CheckBox IsChecked="{Binding Download}" Checked="CheckBox_Checked" Unchecked="CheckBox_Unchecked"/>
                                </StackPanel>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
