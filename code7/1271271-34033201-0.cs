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
            return $"{nameof(MyClass)} has a Gender of { Gender }";
        }
    }
    
    public enum Gender
    {
        Male,
        Female
    }
