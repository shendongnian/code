    public class StudentEqualityComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student a, Student b)
        {
            return a.PersonId == b.PersonId;
        }
        public int GetHashCode(Student s)
        {
            return s.PersonId.GetHashCode(); // or just `return s.PersonId`
        }
    }
