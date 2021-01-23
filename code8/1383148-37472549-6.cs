    public class SampleService
    {
        public SampleService()
        {
            _dbContext = new SampleContext();
        }
    
        readonly SampleContext _dbContext;
    
        public virtual Person GetPersonById(int id)
        {
            return _dbContext.Persons.FirstOrDefault(x => x.ID == id);
        }
    
        public virtual Car GetCarById(int id)
        {
            return _dbContext.Cars.FirstOrDefault(x => x.ID == id);
        }
    
        public virtual IList<Car> GetAllCars()
        {
            return _dbContext.Cars.ToList();
        }
    
        public virtual void UpdatePerson(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));
    
            _dbContext.SaveChanges();
        }
    
        public virtual void UpdateCar(Car car)
        {
            if (car == null)
                throw new ArgumentNullException(nameof(car));
    
            _dbContext.SaveChanges();
        }
    }
