    public class NotifyingBox
    {
        private List<Note> notes = new List<Note>();
        public event Action<NotifyingBox> NoteAdded;
        public IEnumerable<Note> Notes => notes;
        public void AddNote(Note note)
        {
            notes.Add(note);
            NoteAdded?.Invoke(this);
        }
    }
