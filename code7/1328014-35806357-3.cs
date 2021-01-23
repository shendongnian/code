        private static int GetCountOfTimesWorkedTogether(IEnumerable<Student> studentList, int id1, int id2)
        {
            var count = studentList.Where(s => s.StudentID_FK == id1 && s.AssistantID_FK == id2 || s.StudentID_FK == id2 && s.AssistantID_FK == id1).Count();
            return count;
        }
