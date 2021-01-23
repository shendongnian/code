    public class ClassRoom
    {
        public static ClassRoom CreateClassRoom(Person person = null)
        {
            if(person == null)
                return new ClassRoom();
            else 
                return new ClassRoom(person,person.Name);
        }
        private ClassRoom()
        {
        }
        private ClassRoom(Person person, string name)
        {
            //Not sure why you would do this, because you're setting it to what it already is.
            person.Name = name;
        }
    }
