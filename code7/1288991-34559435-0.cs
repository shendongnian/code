        public class Person
        {
            public int Age;
            public string Name;
            public string Major;
            public override string ToString()
            {
                return Name + ": " + Age + " , Major in " + Major;
            }
            public Person(int Age, string Name, string Major)
            {
                this.Age = Age;
                this.Name = Name;
                this.Major = Major;
            }
            public int CompareTo(Person person, string updown, string what)
            {
                int comp = 0;
                what = what.ToLower();
                switch (what)
                {
                    case "name":
                        comp = this.Name.CompareTo(person.Name); //1.
                        break;
                    case "age":
                        comp = this.Age.CompareTo(person.Age);
                        break;
                    case "major":
                        comp = this.Major.CompareTo(person.Major); //3.
                        break;
                }
                if (updown == "Descending")
                { 
                    return comp *= -1; 
                }  //4.
                else 
                { 
                    return comp; 
                }
            }
        }​
