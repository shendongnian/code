    public interface IMyInterface
    { }
    public class bar
    { }
    [Export("SomeController", typeof(bar))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class foo : bar
    { }
    [Export("SomeModule", typeof(IMyInterface))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class ifoo : IMyInterface
    { }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            Type type = a.GetTypes()
                .Where(t => t.GetInterface(typeof(IMyInterface).Name) != null).FirstOrDefault();
            if (type != null) // type is of Type ifoo
            {
                Console.WriteLine("Success!"); 
            }
        }
    }
