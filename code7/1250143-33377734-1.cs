    using System.Collections.Generic;
    ...
    public class SortByName : IComparer<Student> {
        public int Compare(Student st1, Student st2) {
            return st1.Name.CompareTo(st2.Name);
        }
    }
    ...
    group.Sort(new Student.SortByName());
