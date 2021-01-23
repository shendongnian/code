        private string combotextfilter = "<No Selection>";
        public string ComboTextFilter
        {
            get { return combotextfilter; }
            set
            {
                if (value != null && value.IndexOf("ComboModel") != -1) return;
                combotextfilter = value;
                NotifyPropertyChanged(nameof(ComboTextFilter));
            }
        }
        private void CheckBox_Checked_Unchecked(object sender, RoutedEventArgs e)
        {
            switch (((ObservableCollection<ComboModel>)combobox.ItemsSource).Count(x => x.IsChecked))
            {
                case 0:
                    ComboTextFilter = "<No Selection>";
                    break;
                case 1:
                    ComboTextFilter = ((ObservableCollection<ComboModel>)combobox.ItemsSource).Where(x => x.IsChecked).First().Eintrag;
                    break;
                default:
                    ComboTextFilter = ((ObservableCollection<ComboModel>)combobox.ItemsSource).Where(x => x.IsChecked).Select(x => x.Eintrag).Aggregate((i, j) => i + " | " + j);
                    //ComboTextFilter = "<Multiple Selected>";
                    break;
            }
            NotifyPropertyChanged(nameof(C_Foreground));
        }
        public bool DropOpen
        {
            get { return dropopen; }
            set { dropopen = value; NotifyPropertyChanged(nameof(ComboTextFilter)); }
        }
        private bool dropopen = false;
