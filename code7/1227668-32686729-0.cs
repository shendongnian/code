     UpdateTeacher(int teacherId)
        {
            var teacher = teacherRepository.Find(teacherId);
            UpdateYoga(teacher);
        }
        private void UpdateYoga(Teacher teacher)
        {
 	        foreach(var yoga in teacher.YogaClasses)
            {
                db.Context.Attach(yoga);
                yoga.YogaStyle = whatEverValue;
            }
            db.context.SaveChanges();
        }
    
