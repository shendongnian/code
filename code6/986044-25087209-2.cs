    public class LetterGradeCalculator<T> where T : ILetterGradeFactory, new()
    {
        private readonly ILetterGradeFactory _factory;
        public GradeCalculator() {
            _factory = new T();
        }
        public string GetLetterGrade(int numericalGrade) {
            return _factory.CreateLetterGrade(numericalGrade);
        }
    }
    public interface ILetterGradeFactory
    {
        string GetLetterGrade(int numericalGrade);
    }
    public class SixPointLetterGradeCalculator : ILetterGradeFactory
    {
        public string GetLetterGrade(int numericalGrade) {
            if (numericalGrade >= 94)
                return "A";
            ...
        }
    }
