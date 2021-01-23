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
                RecheckSaveCommand();
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
                if (_selectedNote != null)
                {
                    PropertyChangedEventManager.RemoveHandler(_selectedNote, SelectedNoteTextChanged, nameof(Note.Text));
                }
                _selectedNote = value;
                if (_selectedNote != null)
                {
                    PropertyChangedEventManager.AddHandler(_selectedNote, SelectedNoteTextChanged, nameof(Note.Text));
                }
                OnPropertyChanged();
            }
        }
        private void SelectedNoteTextChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            RecheckSaveCommand();
        }
        private void RecheckSaveCommand()
        {
            var command = this.SaveCommand as WpfBindingOneWayWithSaveButton.SaveCommand; //"this." and "WpfBindingOneWayWithSaveButton." are not necessary but I wanted to be explicit.
            if (command != null)
            {
                command.RaiseCanExecuteChanged();
            }
        }
        //...
     }
