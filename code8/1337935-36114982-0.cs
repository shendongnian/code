        public void AddSeries()
        {            
            MediaDB.db.CreateTable<BaseSeries>();
            MediaDB.db.CreateTable<BaseSeason>();
            MediaDB.db.CreateTable<BaseEpisode>();
            MediaDB.db.InsertWithChildren(SelectedSeries, recursion: true);            
        }
