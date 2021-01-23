    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    public class C
    {
        [method: DllImport("c")]
        public extern static event System.Action G;
    }
