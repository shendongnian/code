    <DataTemplate x:Key="GenericList3StateCheckbox">
        <CheckBox IsThreeState="True" Checked="FilterChanged" Unchecked="FilterChanged" Content="{Binding Caption}" IsChecked="{Binding State}"/>
    </DataTemplate>
    List<FilterItemVM> LvGenres = new List<FilterItemVM>();
    public class FilterItemVM : INotifyPropertyChanged
    {
        private string _caption;
        public string Caption
        {
            get { return _caption; }
            set
            {
                _caption= value;
                OnPropertyChanged();
            }
        }
        private bool? _state;
        public bool? State
        {
            get { return _state; }
            set
            {
                _state= value;
                OnPropertyChanged();
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    private bool ListStatusFilter(MovieItem movie)
    {
        List<string> itemGengres = movie.Genres.Split(',').Select(g => g.Trim()).ToList();
        List<string> obligatoryGengres = LvGenres.Where(fi => fi.State.HasValue && fi.State.Value == true).Select(fi => fi.Caption).ToList();
        List<string> forbiddenGengres = LvGenres.Where(fi => fi.State.HasValue && fi.State.Value == false).Select(fi => fi.Caption).ToList();
        bool isGenresMatched = obligatoryGengres.All(g => itemGengres.Contains(g)) && !forbiddenGengres.Any(g => itemGengres.Contains(g));
        return isGenresMatched && (LvFilter_Watching.IsChecked.HasValue && LvFilter_Watching.IsChecked.Value && movie.lMyStatus == "Watching") ||
               (LvFilter_OnHold.IsChecked.HasValue && LvFilter_OnHold.IsChecked.Value && movie.lMyStatus == "On-Hold") ||
               (LvFilter_PlanToWatch.IsChecked.HasValue && LvFilter_PlanToWatch.IsChecked.Value && movie.lMyStatus == "Plan To Watch") ||
               (LvFilter_Dropped.IsChecked.HasValue && LvFilter_Dropped.IsChecked.Value && movie.lMyStatus == "Dropped") ||
               (LvFilter_Completed.IsChecked.HasValue && LvFilter_Completed.IsChecked.Value && movie.lMyStatus == "Completed");
    }
