    using System;
    
    namespace pawlowski_Catherine_Lab3 {
        public class Course {
            protected string description;
            protected string prefix;
            protected double number;
            protected double hours;
    
        }
        public Course() {
            this.hours = "3.00";
        }
        public Course(string description, string prefix, double number, double hours) {
            this.description = description;
            this.prefix = prefix;
            this.number = number;
            this.hours = hours;
        }
        public override string ToString() {
            return string.Format("Course: " + prefix + "\nCourse Number: " + number + "\nDescription: " + description + "\nCredit hours: " + hours);
        }
    }
