     public class UserModel : IHaveNotesBaseModel
        {
            public List<NoteModel> Notes { get; set; }
            List<INoteModel> IHaveNotesBaseModel.Notes
            {
                get { return Notes.Cast<INoteModel>().ToList(); }
                set { Notes = value.Cast<NoteModel>().ToList(); }
            }
        }
