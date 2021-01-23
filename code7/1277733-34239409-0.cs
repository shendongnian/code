       public MainViewModel()
        {
           LinkList = new LinkCollection();
           KalenderList = new ObservableCollection<Kalender>();
           KalenderList = DataHandler.HentKalendere();
            foreach (var kalender in KalenderList)
            {
                LinkList.Add(new Link
                {
                    DisplayName = kalender.Navn,
                    Source = new Uri("/Pages/UgePage.xaml#"+kalender.Navn, UriKind.Relative)
                });
            }
            _selectedKalender = LinkList[0].Source;
