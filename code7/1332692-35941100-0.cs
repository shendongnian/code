     public class SimpleDirtyTracker
     {
        private Form _frmTracked;  
        private bool _isDirty;
        public SimpleDirtyTracker(Form frm)
        {
          _frmTracked = frm;
           AssignHandlersForControlCollection(frm.Controls);
        }
      
         // property denoting whether the tracked form is clean or dirty
         public bool IsDirty
         {
           get { return _isDirty; }
           set { _isDirty = value; }
         }
          // methods to make dirty or clean
         public void SetAsDirty()
         {
           _isDirty = true;
         }
 
         public void SetAsClean()
         {
           _isDirty = false;
         }
         private void SimpleDirtyTracker_TextChanged(object sender, EventArgs e)
         {
          _isDirty = true;
         }
         // recursive routine to inspect each control and assign handlers accordingly
       private void AssignHandlersForControlCollection(
       Control.ControlCollection coll)
       {
         foreach (Control c in coll)
        {
          if (c is TextBox)
              (c as TextBox).TextChanged 
                += new EventHandler(SimpleDirtyTracker_TextChanged);
          // ... apply for other desired input types similarly ...
          // recurively apply to inner collections
          if (c.HasChildren)
              AssignHandlersForControlCollection(c.Controls);
      }
    }
