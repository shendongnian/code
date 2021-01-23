    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    string minute;
                    if (j == 0)
                    {
                        minute = "00";
                    }
                    else
                    {
                        minute = "30";
                    }
                    //view.cmbStartZeit.Items.Add(i.ToString() + ":" + j.ToString());
                    //startZeit.Content = i.ToString() + ":" + minute;
                    //endZeit.Content = i.ToString() + ":" + minute;
                    startTime.Items.Add(i.ToString("00") + ":" + minute);
                }
            }
        }
        private void StartTime_OnSelected(object sender, RoutedEventArgs e)
        {
            var time = TimeSpan.Parse(startTime.SelectedValue.ToString());
            // startDate.SelectedDate could be null, so do some checking before
            startDate.SelectedDate = ((DateTime)startDate.SelectedDate).Add(time);
        }
    }
