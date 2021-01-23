     class Program
        {
            static void Main(string[] args)
            {
    
                UserModel um = new UserModel();
    
                um.Notes = new List<NoteModel>();
                um.Notes.Add(new NoteModel { MyProperty = 1 });
                um.Notes.Add(new NoteModel { MyProperty = 100 });
                um.Notes.Add(new NoteModel { MyProperty = 10 });
                um.Notes.Add(new NoteModel { MyProperty = 10000 });
    
                List<INoteModel> Notes = um.Notes.Cast<INoteModel>().ToList();
                ((IHaveNotesBaseModel)um).Notes = Notes;
    
                
    
            }
    
    
        }
    
        // Interface is in a lower level project that only has
        // interfaces in it, no concretes
        public interface IHaveNotesBaseModel
        {
            List<INoteModel> Notes { get; set; }
        }
        // Concrete implements the interface explicitly so it can have
        // the Concrete for ServiceStack serialization/deserialization
        public class UserModel : IHaveNotesBaseModel
        {
            public List<NoteModel> Notes { get; set; }
            List<INoteModel> IHaveNotesBaseModel.Notes
            {
                get { return Notes.Cast<INoteModel>().ToList(); }
                set { Notes = value.Cast<NoteModel>().ToList(); }
            }
        }
