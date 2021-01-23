    public partial class frmToDo : Form
    {
        public frmToDo()
        {
            InitializeComponent();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmToDoDetails frm = new frmToDoDetails();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] arr = new string[2];
                ListViewItem itm; 
                arr[0] = frm.TaskTitle;
                arr[1] = frm.Description;
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
             
        }
        private void frmToDo_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            //Add column header
            listView1.Columns.Add("Title", 100);
            listView1.Columns.Add("Desc", 70); 
             
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
          ListViewItem currentItem=   listView1.SelectedItems[0];
          frmToDoDetails frm = new frmToDoDetails();
          frm.TaskTitle = currentItem.SubItems[0].Text;
          frm.Description = currentItem.SubItems[1].Text;
          frm.EditMode = true;
          if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
          {
                 currentItem.SubItems[0].Text=frm.TaskTitle;
                currentItem.SubItems[1].Text=frm.Description;
          }
        }
    }
