    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                Partner DefaultTitle = new Partner();  // title = "Employee"
                DefaultTitle.Display();
                Console.ReadLine();
            }
        }
    
        public abstract class Employee
        {
            public virtual string title { get; set; }  // underlying field
    
          public string Title
          {
              get { return title; }
              set { this.title = value; }
          }  // read-only property
    
          public Employee() { // do some stuff all children need 
              this.title = "Employee";
          }  // constructor
    
          public virtual void Display()
          {
            Console.WriteLine("Title: {0}", Title);
          }
        }
    
    
        public class Director : Employee
        {
          public override string title { get; set; }  // shadowing field works here
    
          public int NumberOfProjectsManaged { get; set; }  // additional property
    
          public Director() : base() {
              this.title = "Director";
          } // constructor
    
          public override void Display()
          {
            base.Display();
          }
        }
    
    
        public class Partner : Director
        {
          // there are more than two in the actual code, but this is a MWE
          public override string title { get; set; }
          public enum SpecificTitle
          {
            Principal,
            Partner
          };
    
          public Partner() : base() 
          {
            this._setTitle(SpecificTitle.Partner);  // defaults to Partner
          }
    
          public Partner(SpecificTitle jobTitle) 
          {
            this._setTitle(jobTitle);  // overloaded ctor allows user to specify
          }
    
          private void _setTitle(SpecificTitle jobTitle)
          {
            switch (jobTitle)
            {
              case SpecificTitle.Principal:
                this.title = "Principal";
                break;
              case SpecificTitle.Partner:
              default:
                this.title = "Partner";
                break;
            }
          }
        }
    }
