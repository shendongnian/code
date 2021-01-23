    [HttpPost]
        public async Task<ActionResult> Update(StudentViewModel[] studentData) //notice async in this line
        {
            try
            {
                IEnumerable<Task> tasksQuery = studentData.Select(async s => await UpdateStudentData(s));
    
                List<Task> tasks = tasksQuery.ToList();
    
                await Task.WhenAll(tasks); //Notice await here
    
                return Json(new { success = true });
            }
            catch (EntityCommandExecutionException ex)
            {
                log.Warn(string.Format("{0}: {1}", "Operation Failed", ex.ToString()));
                return Json(new { success = false });
            }
        }
    
        private async Task UpdateStudentData(StudentViewModel sm)
        {
            var student= db.Students.FindAsync(sm.Id);
            if (student.Result != null)
            {
                student.Result.SectionId = sm.SectionId;
                student.Result.PreferenceOrder = sm.PreferenceOrder ;
                db.Entry(student.Result).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }
