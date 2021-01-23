     class Program
    {
        static void Main(string[] args)
        {
            var vacancies = new List<Vacancy>
            {
                new Vacancy {Id = 1, Details = "flat"},
                new Vacancy {Id = 2, Details = "restaurant"}
            };
            List<VacancyExtended> vacanciesExtended = vacancies.Select(p => new VacancyExtended(p)).ToList();
            foreach (var v in vacanciesExtended)
            {
                Console.WriteLine(v.Details);
                
            }
            Console.ReadKey();
        }
    }
    public class Vacancy
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public Vacancy(){ }
        public Vacancy(Vacancy vacancy)
        {
            Id = vacancy.Id;
            Details = vacancy.Details;
        }
    }
    public class VacancyExtended : Vacancy
    {
        public VacancyExtended(Vacancy vacancy) : base(vacancy)
        {
            
        }
    
        public string AdditionalInfo { get; set; }
    }
