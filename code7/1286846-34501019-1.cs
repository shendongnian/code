    public ActionResult Edit(MyNote noteToEdit)
    {
    	var oldNote = notes.FirstOrDefault(n => n.Id == noteToEdit.Id);
    
    	if(oldNote == null)
    		return View(); //With some error message;
    
    	oldNote.Title = noteToEdit.Title;
    	oldNote.OprettelsesDato = DateTime.Now;
    	oldNote.Note = noteToEdit.Note;
    
    	return RedirectToAction("Index", "Note");
    }
    
    public ActionResult Delete(int id)
    {
    	var noteToRemove = notes.FirstOrDefault(x => x.Id == id);
    
    	if(noteToRemove == null)
    		return View(); //With some error message;
    
    	notes.Remove(noteToRemove);
    	return RedirectToAction("Index", "Note");
    }
