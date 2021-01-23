       [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Notes_Update([DataSourceRequest]DataSourceRequest request, NoteForm note)
        {
            var dbo = new UsersContext();
            NoteForm nf = (from row in dbo.Note
                          where row.id == note.id
                          select row).First();
            nf.languageId = note.languageId;
            nf.Text = note.Text;
            nf.Title = note.Title;
            dbo.SaveChanges();
            return Json(new[] { nf }.ToDataSourceResult(request, ModelState));
        }
