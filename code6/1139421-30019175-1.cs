    <TextBox HorizontalAlignment="Left"
                     Background="Transparent"
                     Margin="0,81,0,0" 
                     TextWrapping="Wrap" 
                     Text="{Binding NoteTitle, Mode=TwoWay}" 
                     VerticalAlignment="Top" 
                     Height="50" Width="380" 
                     Foreground="#FFB0AEAE" FontSize="26"/>
    
    private string _NoteTitle;
    public string NoteTitle
    {
        get { return _NoteTitle; }
        set { _NoteTitle= value; }
    }
    
    private ObservableCollection<Note> _notes;
    
    public void AddNote(string NoteName)
    {
        System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
        {
            System.Diagnostics.Debug.WriteLine("AddNote Called...");
            _notes.Add(new Note() {NoteTitle = NoteName});
        });
    }
