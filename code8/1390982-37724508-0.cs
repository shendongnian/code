    public class NoteRepository : INoteRepository, IDisposable
    {
        private MyDbContext context;
        public NoteRepository(MyDbContext _context)
        {
            context = _context;
        }
        public async Task DeleteNoteAsync(Guid id)
        {
            Note note = await context.Notes.FindAsync(id);
            context.Notes.Remove(note);
        }
        public async Task<Note> GetNoteByIdAsync(Guid id)
        {
            return await context.Notes.FindAsync(id);
        }
        public async Task<List<Note>> GetNotesAsync()
        {
            return await context.Notes.ToListAsync();
        }
        ...
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
        ...
        public async Task<Note> GetNoteById(Guid? id)
        {
            return await context.Notes.FindAsync(id);
        }
        #endregion
    }
