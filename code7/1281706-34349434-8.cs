    public class SomeView
    {
        dynamic fieldBox = null;
        dynamic valueBox = null;
        dynamic dbValues = null;
        dynamic MessageBox = null;
        private List<Person> People = new List<Person>();
        private void LoadDB()
        {
            //Structure
            string myStruct = "NAME\nAGE\nSEX\nSKILL";
            string db = "John\t20\tMale\tNoob\n" +
                           "Joe\t20\tMale\tMedium\n" +
                           "Jessica\t27\tFemale\tExpert\n" +
                           "John\t21\tMale\tMedium";
            //Load struct to combobox
            string[] mbstr = myStruct.Split('\n');
            for (int i = 0; i < mbstr.Length; i++)
            {
                fieldBox.Items.Add(mbstr[i]);
            }
            People.Clear();
            foreach(var row in db.Split('\n'))
            {
                var columns = row.Split('\t');
                Person p = new Person();
                p.Name = columns[0];
                p.Age = int.Parse(columns[1]);
                p.Sex = (Person.Sexs)Enum.Parse(typeof(Person.Sexs), columns[2]);
                p.SkillLevel = (Person.SkillLevels)Enum.Parse(typeof(Person.SkillLevels), columns[2]);
                People.Add(p);
                dbValues.Items.Add(string.Format("{0}-{1}", p.Name, p.Age);
            }
        }
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public enum Sexs
            {
                Male,
                Female
            }
            public Sexs Sex { get; set; }
            public enum SkillLevels
            {
                Noob,
                Medium,
                Expert
            }
            public SkillLevels SkillLevel { get; set; }
        }
        void ValueBoxKeyDown(object sender, dynamic e)
        {
            if (e.KeyCode != "enter")
                return;
            Person p = this.People[dbValues.SelectedIndex];
            switch((int)fieldBox.SelectedIndex)
            {
                case 0: p.Name = valueBox.Text; break;
                case 1: p.Age = int.Parse(valueBox.Text); break;
                case 2: p.Sex = (Person.Sexs)Enum.Parse(typeof(Person.Sexs), valueBox.Text); break;
                case 3: p.SkillLevel = (Person.SkillLevels)Enum.Parse(typeof(Person.SkillLevels), valueBox.Text); break;
                default: throw new NotImplementedException();
            }
            MessageBox.Show("Value set: " + old + " to " + valueBox.Text + ".");
        }
    }
