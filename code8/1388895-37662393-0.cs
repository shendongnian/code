    public class Person
    {
    	public int ID { get; set; }
    	public string Name { get; set; }
    }
    
    public Form1()
    {
    	InitializeComponent();
    
    	List<Person> persons = new List<Person> {new Person() {ID = 0, Name = "one"}, new Person() {ID = 1, Name = "two"}, new Person() {ID = 2, Name = "tree"}, new Person() {ID = 3, Name = "four"}};
    	dataGridView1.DataSource = persons;
    }
    
    private System.Windows.Forms.DataGridView dataGridView1;
    private void InitializeComponent()
    {
    	this.dataGridView1 = new System.Windows.Forms.DataGridView();
    	((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
    	this.SuspendLayout();
    	// 
    	// dataGridView1
    	// 
    	this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
    	this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    	this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
    	this.dataGridView1.Location = new System.Drawing.Point(0, 0);
    	this.dataGridView1.Name = "dataGridView1";
    	this.dataGridView1.Size = new System.Drawing.Size(284, 262);
    	this.dataGridView1.TabIndex = 0;
    	// 
    	// Form1
    	// 
    	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    	this.ClientSize = new System.Drawing.Size(284, 262);
    	this.Controls.Add(this.dataGridView1);
    	this.Name = "Form1";
    	this.Text = "Form1";
    	((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
    	this.ResumeLayout(false);
    
    }
