    public partial class frmPrincipal : MyFormBase // inherit from your own base
    {
        ...
    }
    public partial class frmMyOtherForm : MyFormBase // inherit from your own base
    {
        ...
    }
    public class MyFormBase : Form  // your own base with the to be shared method
    {
        protected void LocalizarCategoria() // protected might be enough
        {
            ...
        }
    }
