      <CalendarView x:Name="calendar" CalendarViewDayItemChanging="CalendarView_CalendarViewDayItemChanging"></CalendarView>
    public MainPage()
            {
                this.InitializeComponent();
                this.Loaded += MainPage_Loaded;
            }
    
            private void MainPage_Loaded(object sender, RoutedEventArgs e)
            {
                var parent = (todayItem.Parent as CalendarPanel);
                Rect rect = todayItem.TransformToVisual(parent).TransformBounds(new Rect(0,0, parent.ActualWidth, parent.ActualHeight ));
              (parent.Parent as ScrollViewer).ScrollToVerticalOffset(rect.Y);
                (parent.Parent as ScrollViewer).UpdateLayout();                           
            }
    
            CalendarViewDayItem todayItem;
            private void CalendarView_CalendarViewDayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
            {
                CalendarViewDayItem item = args.Item;
                DateTime date = DateTime.Now.Date.Date;
                if (item.Date.DateTime.Date == date)
                {
                    this.todayItem = item;
                    ((item.Parent as CalendarPanel).Parent as ScrollViewer).ViewChanged += MainPage_ViewChanged;
    
                }
            }
