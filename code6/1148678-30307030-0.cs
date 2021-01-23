     MDIParent1 parent = new MDIParent1();
     public void BuildMenu(IMenuContainer container)
     {
        parent = container.Parent;
     } 
     
     public void NewForm(object sender, System.EventArgs e)
     {
        Form3 childForm = new Form3();
        childForm.MdiParent = parent.Parent;
        childForm.StartPosition = FormStartPosition.CenterParent;
        childForm.Show();
     }
