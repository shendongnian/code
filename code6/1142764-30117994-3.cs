    public class Employee
    {
        /// <summary>
        /// employee's ID
        /// </summary>
        public int ID { get; set; }
    
        /// <summary>
        /// employuee's name
        /// </summary>
        public string Name { get; set; }
    
        /// <summary>
        /// list of personal skills
        /// </summary>
        public List<string> PersSkills { get; private set; }
    
        /// <summary>
        /// list of tecnical skills
        /// </summary>
        public List<string> TechSkills { get; private set; }
    
        /// <summary>
        /// конструктор
        /// </summary>
        public Employee()
        {
            this.PersSkills = new List<string>();
            this.TechSkills = new List<string>();
        }
    
        /// <summary>
        /// конструктор
        /// </summary>
        public Employee(int id, string name, string[] persSkills, string[] techSkills)
        {
            this.ID = id;
            this.Name = name;
            this.PersSkills = new List<string>(persSkills);
            this.TechSkills = new List<string>(techSkills);
        }
    }
