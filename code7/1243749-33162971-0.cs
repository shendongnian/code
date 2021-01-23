    // This represents individual note
    public class Note 
    {
    	// Initialize keywords list in constructor
    	// in order to avoid Null reference exception.
    	public Note() {
    		Keywords = new List<string>();
    	}
    	
    	public string Title { get; set; }
    	public string Content { get; set; }
    	public List<string> Keywords { get; set; }
    }
    
    // In main code, you can simply have List<Note> to hold collection of any no of notes.
    // Also, when user adds a note you will create a new Note instance and add to collection.
    List<Note> notes = new List<Note>();
    
    Note newNote = new Note();
    newNote.Title = "Note 1";
    newNote.Content = "Note 1 Content";
    newNote.Keywords.Add("Test1");
    
    notes.Add(newNote);
