    public class MyForm : Form
    {
        //Class-level variables, accessible to all methods in the class
        private ListBox _list;  
        private ListBox _list2;
        private void AddNewPr_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            _list = new ListBox();
            _list2 = new ListBox();
            PictureBox picBox = new PictureBox();
            picBox.Click = picBox_Click;
            //More stuff here
            //Add the controls        
            tabControl1.Controls.Add(tab);
            tab.Controls.Add(list);
            tab.Controls.Add(list2);
            tab.Controls.Add(pictureBox);
        }
        private void picBox_Click(object sender, EventArgs e)
        {
            //_list and _list2 are in scope here because they are defined at the class-level
            _list.Items.AddRange(new object()["Id", "Name"]);
        }
    }
