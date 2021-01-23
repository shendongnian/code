    using System.ComponentModel;
    using System.Windows.Forms;
    
    #if DEBUG
    public abstract partial class AbstractGenericBase<T> : NonGenericBase
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
    public class NonGenericBase : GenericBase<object> { }
    #endif
