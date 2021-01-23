    public partial class frmTasks : Form
    {
           [Import(typeof (Exec.Core.Interfaces.IHost))] 
           public Exec.Core.Interfaces.IHost Host;
    
          private void Load_Form(object sender, EventArgs e)
          {
             Host = Program._modHandler.Host.GetHost; << added this to initialize host
    
               other stuff....
          }
          other stuff that now works
    }
