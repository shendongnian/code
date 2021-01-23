    public interface IRepository<TBusiness>
    {
        TBusiness Add(TBusiness entity);
    }
    public class PersonsRepo:Repository<Domain.Person>
    {
        public Domain.Person Add(Domain.Person entity)
        { 
            DataAccess.Entities.Person dbPerson = Mapper.Map<DataAccess.Entities.Person>(person);
            dbContext.People.Add(dbPerson);
            cbContext.SaveChanges(); //check this, you are saving it so you return a filled ID person,but you are inside transaction so no problem with rollback!!
            return  Mapper.Map<Domain.Person>(dbPerson);
        } 
    }
