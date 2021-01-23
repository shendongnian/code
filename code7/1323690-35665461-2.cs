    public class PersonSection : ConfigurationSection
    {
        [ConfigurationProperty("FirstName")]
        public PersonElement FirstName
        {
            get { return this["FirstName"] as PersonElement; }
            set { this["FirstName"] = value; }
        }
        [ConfigurationProperty("LastName")]
        public PersonElement LastName
        {
            get { return this["LastName"] as PersonElement; }
            set { this["LastName"] = value; }
        }
        [ConfigurationProperty("Age")]
        public PersonElement Age
        {
            get { return this["Age"] as PersonElement; }
            set { this["Age"] = value; }
        }
        public Person CreatePersonFromConfig()
        {
            return new Person()
            {
                FirstName = this.FirstName.InnerText,
                LastName = this.LastName.InnerText,
                Age = Convert.ToInt32(this.Age.InnerText)
            };
        }
    }
