    public class PeopleManager{
    
      private IDataWriter<Person> _personWriter;
    
      public PeopleManager(IDataWriter<Person> personWriter){
        _personWriter = personWriter;
      }
    
      public void ImportantMethodToTest(Person person){
        if(..important conditionsTested...){
          _personWriter.Update(person);
        }
      }
    }
