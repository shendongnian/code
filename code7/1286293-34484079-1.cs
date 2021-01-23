    public class Program
    {
        static void Main(string[] args)
        {
            MethodInfo info2 = Type.GetType("A.PW, Assembly-CSharp").GetMethod("G", BindingFlags.Static | BindingFlags.NonPublic, null, new Type[] { typeof(int) }, null);
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine((string) info2.Invoke(null, new object[] {75432}));
            System.Diagnostics.Debug.WriteLine((string)info2.Invoke(null, new object[] {45634}));
            System.Diagnostics.Debug.WriteLine((string)info2.Invoke(null, new object[] {70345}));
            System.Diagnostics.Debug.WriteLine((string)info2.Invoke(null, new object[] {3456}));
            System.Diagnostics.Debug.WriteLine((string)info2.Invoke(null, new object[] {4734}));
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");
        } 
    }
