    public class Student
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public decimal AverageMark { get; set; }
        public string Name { get; set; }
        public string University { get; set; }
        public bool IsValidStudent(Criteria criteria)
        {
            return IsValidByAge(criteria) 
                && IsValidByMarks(criteria) 
                && IsValidByUniversity(criteria);
        }
        private bool IsValidByAge(Criteria criteria)
        {
            switch (criteria.OperationType)
            {
                case Criteria.Operation.GreaterThan:
                    return Convert.ToInt32(criteria.OperationValue) > this.Age;
                case Criteria.Operation.LessThan:
                    return Convert.ToInt32(criteria.OperationValue) < this.Age;
                case Criteria.Operation.EqualTo:
                    return Convert.ToInt32(criteria.OperationValue) == this.Age;
                default:
                    return false;
            }
        }
        private bool IsValidByMarks(Criteria criteria)
        {
            // etc...
        }
        private bool IsValidByUniversity(Criteria criteria)
        {
            // etc...
        }
    }
