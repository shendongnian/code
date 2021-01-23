    public ActionResult UpdateStudent(int studentId)
    {
         using(var entities = new SalesOrderEntities())
         {
              // Get your student
              var student = entities.Students.FirstOrDefault(s => s.StudentID == studentId);
              if(student == null)
              {
                   // Student wasn't found
                   return HttpNotFound();
              }
              // Create a view with the existing student data
              return View(student);
         }
         
    }
    [HttpPost]
    public bool UpdateStudent(UpdateStudentViewModel viewModel)
    {
         try
         {
             using(var entities = new SalesOrderEntities())
             {
                  // Retrieve your existing student (or other entities)
                  var existingStudent = entities.Students.FirstOrDefault(s => s.StudentID == viewModel.StudentID);
                  // Now that you have your entity, update the appropriate properties
                  existingStudent.Property = viewModel.Property;
                  // Then finally save your changes
                  entities.SaveChanges();
             }
         }
         catch(Exception ex)
         {
             // Something went wrong updating the user
         }
    }
