    class Program
    {
        static void Main(string[] args)
        {
            //set up students
            var student1 = new Student() { Age = 20, AverageMark = 5, Name = "Ihor", University = "Lviv National University" };
            var student2 = new Student() { Age = 20, AverageMark = 5, Name = "SomeLongName", University = "Lviv National University" };
            var student3 = new Student() { Age = 20, AverageMark = 5, Name = "Taras", University = "Kyiv National University" };
            var student4 = new Student() { Age = 20, AverageMark = 5, Name = "Marko", University = "Some University" };
            var student5 = new Student() { Age = 20, AverageMark = 4, Name = "Tanya", University = "Lviv National University" };
            var student6 = new Student() { Age = 22, AverageMark = 4, Name = "Ira", University = "" };
            var students = new List<Student>() { student1, student2, student3, student4, student5, student6 };
            //set up validation rules
            var criteria1 = new Criteria("Age", "Equal", "20");
            var criteria2 = new Criteria("AverageMark", "MoreThen", "4");
            var criteria3 = new Criteria("University", "Contains", "National");
            var criteria4 = new Criteria("University", "StartWith", "Lviv");
            var criteria5 = new Criteria("Name", "Length", "4");
            var criterias = new List<Criteria>() { criteria1, criteria2, criteria3, criteria4, criteria5 };
            var result = new List<Student>();
            foreach (var currentStudent in students)
            {
                var isValid = true;
                foreach (var currentCriteria in criterias)
                {
                    object currentPropertyValue = typeof(Student).GetProperty(currentCriteria.PropertyName).GetValue(currentStudent);
                    IValidator currentValidator = ValidatorFactory.GetValidator(currentCriteria.OperationName);
                    bool validationResult = currentValidator.Validate(currentPropertyValue, currentCriteria.OperationValue);
                    if (!validationResult)
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                    result.Add(currentStudent);
            }
        }
    }
