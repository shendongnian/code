    public class controller : MonoBehavior{
    
        myClass student = new myClass();
    
        [DllImport ("my_dll", EntryPoint="myFunction@12")]
        public static extern void myFunction(myClass c);
    
        void Start(){
            student.name = "John Doe";
            myFunction (student);
        }
    }
    
    [StructLayoutAttribute(LayoutKind.Sequential, size=2)]
    public class myClass {
        //The following MarshalAs may be unnecessary.
        [MarshalAs (UnmanagedType.LPStr)]
        public string name;
        public double height = 0.0;
    }
