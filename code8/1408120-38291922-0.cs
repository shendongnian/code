    using System.ComponentModel;
    using System.Windows.Forms;
    
    #if DEBUG
    public abstract partial class AbstractGenericBase<T> : MyBase
    #else
    public partial class AbstractGenericBase<T> : GenericBase<T>
    #endif
    {
        public AbstractGenericBase()
        {
            InitializeComponent();
        }
    }
    #if DEBUG
    public class MyBase : GenericBase<object> { }
    #endif
