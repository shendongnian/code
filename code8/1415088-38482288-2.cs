    using System;
    using System.Collections.Generic;
    
    namespace SchoolManagementSystem
    {
        public class Student
        {
            public Student(string name)
            {
                Name = name;
            }
    
    		// Add this new property so you get this information
    		// in the value handler
            public School School { get; set; }
    		
            public string Name { get; set; }
            
            public override string ToString()
            {
                return string.Format($"({School.Name}: {Name})");
            }
        }
    }
