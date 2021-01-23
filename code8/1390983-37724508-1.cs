    public class NotesController : Controller
    {
        //private MyDbContext db = new MyDbContext();
        private INoteRepository noterepository;
        //public NotesController(INoteRepository _noterepository)
        //{
        //    _noterepository = noterepository;
        //}
        public NotesController()
        {
            noterepository = new NoteRepository(new MyDbContext());
        }
        // GET: Notes
        public async Task<ActionResult> Index()
        {
            return await View(noterepository.GetNotesAsync());
        }
        // GET: Notes/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = await noterepository.GetNoteByIdAsync(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }
        // GET: Notes/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Notes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Body")] Note note)
        {
            if (ModelState.IsValid)
            {
                note.Id = Guid.NewGuid();
                await noterepository.PostNoteAsync(note);
                await noterepository.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(note);
        }
        // GET: Notes/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = await noterepository.GetNoteByIdAsync(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }
        // POST: Notes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Body")] Note note)
        {
            if (ModelState.IsValid)
            {
                await noterepository.PutNoteAsync(note);
                await noterepository.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(note);
        }
        // GET: Notes/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = await noterepository.GetNoteByIdAsync(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }
        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Note note = await noterepository.GetNoteByIdAsync(id);
            await noterepository.DeleteNoteAsync(id);
            await noterepository.SaveAsync();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                noterepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
