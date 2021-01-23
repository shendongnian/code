    public class TestIndicator : Indicator
    {    
        [StructLayout(LayoutKind.Sequential)]
        public struct TestStruct { public int x, y; }
        static TestStruct[] testy = new TestStruct[2];
                      
        protected override void OnBarUpdate()
        {
            if(CurrentBar < Count - 2) {return;}
                        
            GetDLL.TestFunk( ref testy[0] );
            Print("X0: " + testy[0].x.ToString() + "  Y0: " + testy[0].y.ToString());
            Print("X1: " + testy[1].x.ToString() + "  Y1: " + testy[1].y.ToString());
        }
        
        class GetDLL
        {
            GetDLL() {}
            ~GetDLL() {}
            [DllImport("testdll.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "TestFunk")]
            public static extern void TestFunk( ref TestStruct testy );
        }
    }
