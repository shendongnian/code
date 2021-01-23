    public class SingingAndDancingPerson {
        SingingPerson person;
        public string Talent { get; set; }
        public SingingAndDancingPerson(SingingPerson person)
        {
            this.person = person;
        }
        public string DoTalent()
        {
            this.Talent = person.Talent;
            this.Talent += " and dance";
            return this.Talent;
        }
    }
