    using WMC = System.Windows.Media.Color;
    using MyColorNamespace;
    public class Program
    {
        public void Foo()
        {
             var bar = WMC.ColorMethod();
             var bar2 = MyColorNamespace.FromHSV(0,0,0);
        }
    }
