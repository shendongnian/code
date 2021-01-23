        public class SortByName : IComparer<Student>
        {
            int IComparer.Compare(Student st1, Student st2)
            {
                return st1.Name.CompareTo(st2.Name);
            }
        }
