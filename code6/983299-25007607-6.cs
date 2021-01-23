    public partial class frmMain : Form
    {
        private PrivilegeCheck _privilege;
        public PrivilegeCheck Privilege
        { 
            get { return _privilege; } 
            set
            {
                // Privilege was set, do stuff on your form here.
                
                // Then store the value
                _privilege = value;
            }
        }
    }
