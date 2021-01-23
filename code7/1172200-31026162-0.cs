    public void Main()
    {
        DefinedInstancesTest dit = new DefinedInstancesTest();
        dit.StaticReadOnlyInstancesAreEnumerated();
    }
    
    public abstract class DefinedInstancesBase<T>
    {
        public static IList<T> All
        {
            get
            {
                //if (_All == null)
                //    FillAll();
                return _All;
            }
        }
    
        // correctly named static ctor
        static DefinedInstancesBase() { FillAll(); }
        
        private static void FillAll()
        {
          	Console.WriteLine("FillAll() called...");
            var typeOfT = typeof(T);
            var fields = typeOfT.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            var fieldsOfTypeT = fields.Where(f => f.FieldType == typeOfT);
            _All = new List<T>();
            foreach (var fieldOfTypeT in fieldsOfTypeT)
            {
                _All.Add((T)fieldOfTypeT.GetValue(null));
            }
        }
    
        private static List<T> _All = null;
    }
    
    //[TestClass]
    public class DefinedInstancesTest
    {
        //[TestMethod]
        public void StaticReadOnlyInstancesAreEnumerated()
        {
            //Given
            var expectedClasses = new List<TestClass>
            {
                TestClass.First,
                TestClass.Second,
                TestClass.Third,
            };
    
            //When
            var actualClasses = TestClass.All;
    
            //Then
            for (var i=0; i<expectedClasses.Count; i++)
            {
                //Assert.AreEqual(expectedClasses[i].Id, actualClasses[i].Id);
                if (expectedClasses[i].Id != actualClasses[i].Id)
                  Console.WriteLine("not equal!");
            }
        }
    
        private class TestClass : DefinedInstancesBase<TestClass>
        {
            public static readonly TestClass First;
            public static readonly TestClass Second;
            public static readonly TestClass Third;
    
            public int Id { get; private set; }
          
          static TestClass()
          {
            Console.WriteLine("TestClass() static ctor called...");
            First = new TestClass(1);
            Second = new TestClass(2);
            Third = new TestClass(3);
          }
    
            private TestClass(int pId)
            {
              Console.WriteLine("TestClass({0}) instance ctor called...", pId);
              Id = pId;
            }
        }
    }
    TestClass() static ctor called...
    // First, Second, and Third fields all still equal null at this point!
    FillAll() called...
    TestClass(1) instance ctor called...
    TestClass(2) instance ctor called...
    TestClass(3) instance ctor called...
    // this null reference exception to be expected because the field value actually was null when FindAll() added it to the list
    Unhandled Expecption: 
    System.NullReferenceException: Object reference not set to an instance of an object.
