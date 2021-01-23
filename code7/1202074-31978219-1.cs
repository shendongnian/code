    public static List<Student> GetActualRemovedStudents(List<Student> oldStudents, List<Student> newStudents)
        {
            //Show the removed students
            List<Student> actualRemovedStudents = oldStudents.Where(y => !newStudents.Any(z => z.ID == y.ID)).ToList();
            return actualRemovedStudents;
        }
