    [HttpPost]
    public async Task<ActionResult> Create(Student student)
        {
            Student.Add(student);
            if (ModelState.IsValid)
            {
                var result = db.Students.Add(student);
                await db.SaveChangesAsync();
    
                return View("Details", result);
            }
    
            return View(); //You should add a property to the model called ErrorMessage or something like that, then you could do student.ErrorMessage = "Model state was not valid";, then you could do return View(student); and in the view you could do something like @if (Model.ErrorMessage != null) { @Html.DisplayFor(m=>m.ErrorMessage); }
        }
