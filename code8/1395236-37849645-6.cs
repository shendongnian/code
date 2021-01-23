    public class Associate : Employee
    {
       // Properties
       public int NumberOfEngagements { get; set; }
       
       public Associate() 
       {
          NumberOfEngagements = 0;
       }
        public Associate(int num_engagements)
        {
           this.NumberOfEngagements = num_engagements;
        }
    }
    public class Director : Employee
    {  
       public int NumberOfProjectsManaged { get; set; }  // additional property
  
       public Director() : { NumberOfProjectsManaged = 0; } // constructor
       public Director(int num_projects)
       {
           NumberOfProjectsManaged = num_projects;
       }
       public override void Display()
       {
           base.Display();
           Console.WriteLine("Number of Projects Managed: {0}", NumberOfProjectsManaged);
       }
    }
  
