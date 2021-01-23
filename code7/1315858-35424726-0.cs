      public bool Visibility
        {
            get { return visibility; }
            set
            {
                visibility = value;
                if (visibility == false)
                {
                    Property1 = Property2;
                }
                OnPropertyChanged();
            }
        }
