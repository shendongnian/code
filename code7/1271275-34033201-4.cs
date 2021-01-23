    void Main()
    {
        const int arraySize = 10;
        MyClass[] classes = new MyClass[arraySize];
        for (var i = 0; i < classes.Length; i++)
        {
            if ((i % 2) == 0)
            {
                classes[i] = new MyClass { Gender = Gender.Male };
            }
            else
            {
                classes[i] = new MyClass { Gender = Gender.Female };
            }
        }
    
        for (var i = 0; i < classes.Length; i++)
        {
            Console.WriteLine(classes[i].ToString());
        }
        
    }
    
    public class MyClass
    {
        //Other properties here
        public Gender Gender { get; set; }
    
        //Constructors
    
        //Methods
    
        public override string ToString()
        {
            //Documentation: https://msdn.microsoft.com/en-us/library/dn961160.aspx
            return $"{nameof(MyClass)} has a Gender of { Gender }";
            /*
               If no C# 6 then make your return statement this.
               return string.Format("{0} has a Gender of {1}", typeof(MyClass).Name, Gender);
            */
        }
    }
    
    public enum Gender
    {
        Male,
        Female
    }
