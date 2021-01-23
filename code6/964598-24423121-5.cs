    public class PersonBAL
    {
        public PersonBAL()
        {
        }
        public int Insert(string firstName, string lastName, int age)
        {
            PersonDAL pDAL = new PersonDAL();
            try
            {
                return pDAL.Insert(firstName, lastName, age);
            }
            catch
            {
                throw;
            }
            finally
            {
                pDAL = null;
            }
        }
    }
