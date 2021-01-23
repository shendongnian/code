    public class ChildControl : UserControl
    {
         private void SomeFunction()
         {
             (Parent as ParentForm).Manager.Panel2.Controls.Add(new ReportControl());
         }
    }
