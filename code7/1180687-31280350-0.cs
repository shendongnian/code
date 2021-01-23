    private string folderPath = @"C:\Users\TULPAR\Desktop\elektrik projesi\proje\dosyalar\";
    public Form1()
    {
        this.InitializeComponent();
        this.dataGridView1.DataSource = new System.IO.DirectoryInfo(this.folderPath).GetDirectories();
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      var src = new System.IO.DirectoryInfo(this.folderPath).GetDirectories().Where(di => di.Name.StartsWith(this.textBox1.Text)).ToArray();
      this.dataGridView1.DataSource = src;
    }
