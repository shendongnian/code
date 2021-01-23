    public class MainWindowsViewModel : INotifyPropertyChanged
    {
        private int _selectedIndex = -1;
        private Note _selectedNote;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (_selectedIndex.Equals(value))
                    return;
                _selectedIndex = value;
                CloneSelectedNote();
            }
        }
        private void CloneSelectedNote()
        {
            if (SelectedIndex >= 0)
            {
                SelectedNote = ListOfNotes[SelectedIndex].Clone();
            }
            else
            {
                SelectedNote = null;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Note SelectedNote
        {
            get { return _selectedNote; }
            set
            {
                if(Equals(_selectedNote, value))
                    return;
                _selectedNote = value;
                OnPropertyChanged();
            }
        }
        //... The rest stays the same
    }
