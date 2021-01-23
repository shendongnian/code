    // MainWindow.cs
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Reflection;
    public partial class Form1 : Form
    {
        [ImportMany]
        public List<IPlugin> list = new List<IPlugin>();
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void WindowLoaded(object sender, EventArgs e)
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
    
            var container = new CompositionContainer(catalog);
    
            container.ComposeParts(this);
    
            foreach (var p in list)
            {
                if (p.Check_When_Loaded(this.Name)) break;
            }
        }
    }
