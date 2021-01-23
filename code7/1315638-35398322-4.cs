    public class GroupForm: Form
    {
       private Group _groupInEdit = null;
       public Group Group
       {
           get { return _groupInEdit; }
       }
       public GroupForm(Group grp = null)
       {
           InitializeComponent();
           _groupInEdit = grp;
       }
       private void GroupForm_Load(object sender, EventArgs e)
       {
           if(_grpInEdit != null)
           {
               ... initialize controls with using values from the 
               ... instance passed through the constructor
           }
       }
       private void cmdOK_Click(object sender, EventArgs e)
       {
           // If the global is null then we have been called from 
           // the OnGroupNewClick code so we need to create the Group here
           if(_grpInEdit == null)
              _grpInEdit = new Group();
           _grpInEdit.Name = ... name from your textbox...
           ... other values
       }
    }
