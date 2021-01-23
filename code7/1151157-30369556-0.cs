    public class MyClass : SafeHandle
    {
        private static readonly Destructor DestructorObject = new Destructor();
        ~MyClass()
        {
            Console.WriteLine("Destructor Called");
        }
        protected override bool ReleaseHandle()
        {
            return true;
        }
        public override bool IsInvalid
        {
            get { return false; }
        }
        static void Main(string[] args)
        {
            var myClass = new MyClass(IntPtr.Zero, true);
        }
        private sealed class Destructor
        {
            ~Destructor()
            {
                Console.WriteLine("Static Destructor Called");
            }
        }
        public MyClass(IntPtr invalidHandleValue, bool ownsHandle)
            : base(invalidHandleValue, ownsHandle)
        {
        }
    }
