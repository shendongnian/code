	[AcceptVerbs(HttpVerbs.Post)]
	public ActionResult Notes_Destroy([DataSourceRequest]DataSourceRequest request, NoteForm note)
	{
		var dbo = new UsersContext();
		var results = (from row in dbo.Note
					  where row.id == note.id
					  select row).ToList();
		foreach (var item in results)
		{
			dbo.Note.Remove(item);
		}
		dbo.SaveChanges();
		
		return Json(new[] { note }.ToDataSourceResult(request, ModelState));
	}
