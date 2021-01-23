        /// <summary>
        /// Get or set selected series.
        /// </summary>
        public SeriesBO SelectedSeries
        {
            get { return this.m_SelectedSeries; }
            set
            {
                if (this.m_SelectedSeries != value)
                {
                    m_PrevSelectedSeries = m_SelectedSeries;
                    this.m_SelectedSeries = value;
                    OnPropertyChanged();
                }
            }
        }
        //Method called once a RadListBox is selected
        private void LoadSelectedMarketSeriesDetails()
        {
            if (!IsChanged())
            {
                //If there is no object edited then it should load the new selected object
            }
        }
        private bool IsChanged()
        {
            bool IsChanged = false;
            if (SeriesImageList != null)
                IsChanged = IsChanged || SeriesImageList.Where(x => x.IsChanged || x.IsNew).Count() > 0;
            if (NoteList != null)
                IsChanged = IsChanged || NoteList.Where(x => x.IsChanged || x.IsNew).Count() > 0 || IsChanged;
            if (IsChanged)
            {
                if (ShowMessages.SaveMessageBox())
                {
                    //Hitting Yes in alert should save the values.
                    //When retrieving the SelectedSeries object it shows the recent object selected but i need the last selected one.
                    Save(m_PrevSelectedSeries);
                }
                else
                {
                    //Discard function
                }
            }
            //After a successfull save or discard false is returned
            return false;
        }
        private void Save(object mPrevSelectedSeries)
        {
            //perform the save logic
        }
