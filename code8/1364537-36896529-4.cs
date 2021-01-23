    public class Person
    {
        ...
        public void MergeWith(Person other)
        {
            if (other.Hobbies == null) return;
            if (Hobbies == null) Hobbies = new List<Hobby>();
            foreach (Hobby hobby in other.Hobbies)
            {
                Hobby existingHobby = Hobbies.FirstOrDefault(h => h.Name == hobby.Name);
                if (existingHobby != null)
                {
                    // You may need to make changes here--
                    // What do you do if two hobbies have the same name but different hours?
                    existingHobby.Hours += hobby.Hours;
                }
                else
                {
                    Hobbies.Add(hobby);
                }
            }
        }
    }
