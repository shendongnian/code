    public class Student { /* Shouldn't be disclosed */
        public int Id { get; set; }
        public int Grade { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
    }
    public class StudentViewModel { /* Why should I be worried about ids and grades? */
        public int Id { get; set; }
        public int Grade { get; set; }
    }
