        private List<Website> m_Websites;
        public List<Website> Websites
        {
            get { return m_Websites; }
            set { m_Websites = value; RaisePropertyChanged("Websites"); }
        }
