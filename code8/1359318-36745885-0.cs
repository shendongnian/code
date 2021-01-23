    using System.Xml.Serialization;
    
    (...)
    
     public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
                }
    
                private void Form1_Load(object sender, EventArgs e)
                {
                    listView1.View = View.Details;
                    listView1.FullRowSelect = true;
    
                LoadDataFromDisk();
    
                    listView1.Columns.Add("Due Date", 150);
                    listView1.Columns.Add("Module", 150);
                    listView1.Columns.Add("Title", 150);
                }
    
                private void add(string DueDate, String Module, String Title)
                {
                    string[] row = { DueDate, Module, Title };
                    ListViewItem item = new ListViewItem(row);
    
                    listView1.Items.Add(item);
                }
    
                private void listView1_MouseClick(object sender, MouseEventArgs e)
                {
                    String Duedate = listView1.SelectedItems[0].SubItems[0].Text;
                    String Module = listView1.SelectedItems[0].SubItems[1].Text;
                    String Title = listView1.SelectedItems[0].SubItems[2].Text;
    
                    textBox1.Text = Duedate;
                    textBox2.Text = Module;
                    textBox3.Text = Title;
                }
    
                private void btnAdd_Click(object sender, EventArgs e)
                {
                    add(textBox1.Text, textBox2.Text, textBox3.Text);
    
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
    
                private void btnClear_Click(object sender, EventArgs e)
                {
                    listView1.Items.Clear();
    
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
    
                private void update()
                {
                    listView1.SelectedItems[0].SubItems[0].Text = textBox1.Text;
                    listView1.SelectedItems[0].SubItems[1].Text = textBox2.Text;
                    listView1.SelectedItems[0].SubItems[2].Text = textBox3.Text;
    
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
    
                private void btnUpdate_Click(object sender, EventArgs e)
                {
                    update();
                }
    
                private void delete()
                {
                    if (MessageBox.Show("Are you sure you want to Delete", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
    
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                }
    
                private void btnDelete_Click(object sender, EventArgs e)
                {
                    delete();
                }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                SaveDataToDisk();
            }
    
            private void SaveDataToDisk()
            {
                List<MyData> myDataList = new List<MyData>();
    
                foreach (ListViewItem lvi in this.listView1.Items)
                {
                    MyData d = new MyData();
    
                    d.DueDate = lvi.SubItems[0].Text;
                    d.Module = lvi.SubItems[1].Text;
                    d.Title = lvi.SubItems[2].Text;
    
                    myDataList.Add(d);
                }
    
                XmlSerializer serializer = new XmlSerializer(myDataList.GetType());
                string dataFile = Path.Combine(Application.StartupPath, "data.xml");
                TextWriter fileStream = new StreamWriter(dataFile);
                serializer.Serialize(fileStream, myDataList);
                fileStream.Close();
            }
    
            private void LoadDataFromDisk()
            {
                string dataFile = Path.Combine(Application.StartupPath, "data.xml");
                FileStream fileStream = new FileStream(dataFile, FileMode.Open, FileAccess.Read, FileShare.Read);
    
                List<MyData> data = new List<MyData>();
                XmlSerializer serializer = new XmlSerializer(data.GetType());
    
                data = (List<MyData>)serializer.Deserialize(fileStream);
    
                fileStream.Close();
    
                listView1.Items.Clear();
                foreach (var d in data)
                {
                    add(d.DueDate, d.Module, d.Title);
                }
            }
        }
    
        public class MyData
        {
            public string  DueDate { get; set; }
            public string Title { get; set; }
            public string Module { get; set; }
        }
