    public class GroupForm: Form
    {
       private Group _groupInEdit = null;
       public GroupForm(Group grp = null)
       {
           InitializeComponent();
           _groupInEdit = grp;
       }
       private void GroupForm_Load(object sender, EventArgs e)
       {
           if(_grpInEdit == null)
           ... initialize controls with group values
       }
       private void cmdOK_Click(object sender, EventArgs e)
       {
           if(_grpInEdit == null)
              _grpInEdit = new Group();
           _grpInEdit.Name = ... name from your textbox...
           ... other values
       }
    }
