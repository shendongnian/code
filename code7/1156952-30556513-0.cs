    public interface IWithDate {
        public DateTime DateOfAdding { get; set; }
    }
    public class SavedQuote : IWithDate {
        ...
    }
    public class NoteOnSite : IWithDate {
        ...
    }
    ...
    var mixedList = new List<IWithDate>();
