    using System;
    using System.Collections.Generic;
    namespace Lab4
    {
        public class MainClass
        {
            public static void Main (string[] args)
            {
                Console.WriteLine ("Welcome to the Course Monitoring System v1.0");
    			var c = new Course();
                c.Menu();
                c.Choice();
            }
        }
    	
    	public class Course
        {
            private string courseNumber;
            private string courseName;
            private int courseHours;
            private string descript;
            private string prefix;
            public List<Course> school = new List<Course> ();
            private int howmany=0;
            private int totalcourse=0;
    
            //This section is for returning and adjusting values of private data through the main program.
            public string cn{
                get {return courseNumber; }
                set {if (value != null)
                    cn = value;
                }
            }
            public string name{
                get{ return courseName; }
                set{if (value!="")
                    name=courseName;
                }
            }
            public int hours{
                get {return courseHours; }
                set {if (value != 0)
                    hours = value;
                }
            }
            public string script {
                get {return descript; }
                set {
                    if (value != "")
                        script = value;
                }
            }
            public string pfix {
                get {return prefix; }
                set {if (value != "")
                    pfix = value;
                }
            }
    
    		public Course()
    		{
    		}
            public Course (string pfix, string name, string cn, int hours, string script)
            {
                courseNumber = cn;
                courseName = name;
                courseHours = hours;
                descript= script;
                prefix = pfix;
            }
    
            //This portion of code overrides the string and allows it to output the information held within the constructor.
            public override string ToString ()
            {
                return prefix + " " + courseName+" " + courseNumber + " " + descript + " It is a " + courseHours + " hour course.";
            }
            //The menu application for my program
            public void Menu()
            {
                Console.WriteLine ("Please choose from one of the following options: ");
                Console.WriteLine ("......................................................................");
                Console.WriteLine ("1.)Start a new Course List.");
                Console.WriteLine ("2.)Delete Course from Current List.");
                Console.WriteLine ("3.)Print Current Course List.");
                Console.WriteLine ("4.)Add Course to Current List.");
                Console.WriteLine ("5.)Shutdown Program");
            }
            //This is the controller for the menu. It allows for functionality to control the tasks requested by the user.
            public void Choice()
            {
                int selection=int.Parse(Console.ReadLine());
                while (selection >5 || selection < 1) {
                    Console.WriteLine ("Choice invalid. Please choose between 1 and 5.");
                    selection = int.Parse (Console.ReadLine ());
                }
                if (selection == 4) {
                    Add ();
                    Menu ();
                    Choice ();
                    Console.WriteLine ();
                }
                if (selection == 2) {
                    Delete ();
                    Menu ();
                    Choice ();
                    Console.WriteLine ();
                }
                if (selection == 3) {
                    Print ();
                    Menu ();
                    Choice ();
                    Console.WriteLine ();
                }
                if (selection == 1) {
                    New ();
                    Menu ();
                    Choice ();
                    Console.WriteLine ();
                }
                if (selection == 5) {
                    Console.WriteLine ();
                    Console.WriteLine ("Thank you for using this program for your scheduling needs.");
                }
            }
            //This method when called will print a numbered list of courses refrenced by the created List
            public void Print()
            {
                Console.WriteLine ();
                Console.WriteLine ("Course Name.........Course Number.........Course Description........Course Hours");
                Console.WriteLine ("********************************************************************************");
                for (int i = 0; i < totalcourse; i++) {
                    int place = i + 1;
                    Console.WriteLine (place+".)"+school [i]);
                }
                Console.WriteLine ();
            }
            //This method will add an item to the end of the current list.
            public void Add()
            {
                Console.WriteLine ();
                Console.Write ("How many courses would you like to add at the end of your index?");
                int numberAdded = int.Parse(Console.ReadLine ());
                for (int i = 0; i < numberAdded; i++) {
                    Console.WriteLine ("Please use the following templet for your entries...");
                    Console.WriteLine ("Course Prefix, Course Name, Course Number, Course Hours, Course Description ");
                    school.Add (new Course (prefix = Console.ReadLine (), courseName = Console.ReadLine (), 
                        courseNumber = Console.ReadLine (), courseHours = int.Parse (Console.ReadLine ()), descript = Console.ReadLine ()));
                }
                totalcourse = totalcourse + numberAdded;
                Console.WriteLine ();
            }
            //This method will delete an Item from the list based on the position 0-x based on x-1, the output that is seen by the user. After each iteration it will
            //also create a list so that further deletions can be managed approiatly.
            public void Delete()
            {
                if (totalcourse < 1) {
                    Console.WriteLine ();
                    Console.WriteLine ("There is nothing to delete!");
                    Console.WriteLine ();
                }else{
                    Console.WriteLine ();
                    Console.Write ("How many entries do you wish to remove?");
                    int removed = int.Parse (Console.ReadLine ());
                    for (int i = 0; i < removed; i++) {
                        Console.WriteLine ("Please type the index line number of the item you wish to remove.");
                        int delete = int.Parse (Console.ReadLine ());
                        school.RemoveAt (delete - 1);
                        totalcourse = totalcourse - 1;
                        Print ();
                    }
                }
                Console.WriteLine ();
            }
            //This method is called to create a new list of Courses to be created by the user.
            public void New()
            {
                Console.WriteLine ();
                if (howmany > 0) {
                    Clear ();
                } else {
                    Console.Write ("How many courses do you want to create? ");
                    howmany = int.Parse (Console.ReadLine ());
                    Console.WriteLine ();
                    for (int i = 0; i < howmany; i++) {
                        Console.WriteLine ();
                        school.Add (new Course (prefix = Console.ReadLine (), courseName = Console.ReadLine (), courseNumber = Console.ReadLine (), courseHours = int.Parse (Console.ReadLine ()), descript = Console.ReadLine ()));
                    }
                    totalcourse = totalcourse + howmany;
                    Console.WriteLine ();
                }
            }
            //If there is already a list in place this method will be called and you will be asked if you wish to delete and start new.
            public void Clear()
            {
                Console.WriteLine ();
                Console.Write ("You want to discard old work and start a new list? Enter True or False...:");
                bool clean=bool.Parse(Console.ReadLine());
                if (clean == true) {
                    school.Clear ();
                    totalcourse = 0;
                    howmany = 0;
                    New ();
                } else
                    Console.WriteLine ("No changes will be made. Exiting to Main Menu...");
                Console.WriteLine ();
            }
            /*  public static void Myfour ()
            {
                Console.WriteLine ();
                Console.WriteLine ("These are four pre loaded courses.");
                Course c1 = new Course ("MISSILE", 84, 3, "The Course is for missiles", "CRN");
                Console.WriteLine (c1);
    
                Console.WriteLine ();
            }*/
        }
    }
