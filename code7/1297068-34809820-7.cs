    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    
    namespace HelloWorldMvcApp
    {
    	public class MainViewModel
        {
            public List<Student> Students { get; set; }
            public int SelectedState = 0;
            public int SelectedCity = 0;
        }
    
        public class Student
        {
            [Required]
            public int ID { get; set; }
    
            [Required]
            public string Name { get; set; }
    
            [Required]
            public int StateID { get; set; }
    
            [Required]
            public int CityID { get; set; }
            public List<States> States { get; set; }
            public List<Cities> Cities { get; set; }
        }
    
        public class States
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    
        public class Cities
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }
