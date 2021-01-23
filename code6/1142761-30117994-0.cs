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
            Skills = new List<string>();
        }
    }
