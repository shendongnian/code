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
        /// list of skills
        /// </summary>
        public List<string> Skills { get; set; }
    
        /// <summary>
        /// конструктор
        /// </summary>
        public Employee()
        {
            this.Skills = new List<string>();
        }
    
        /// <summary>
        /// конструктор
        /// </summary>
        public Employee(int id, string name, params string[] skills)
        {
            this.ID = id;
            this.Name = name;
            this.Skills = new List<string>(skills);
        }
    }
