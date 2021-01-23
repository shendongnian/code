    public class PersonWrapper
    {
        private static Person thePerson = null;
    
        public static GetPerson
        {
           get
           {
               if(thePerson==null) { thePerson = new Person();}
               return thePerson;
           }
        }
    }
