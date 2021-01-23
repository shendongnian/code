    public class Person : IComparable<Person> {
    	public int Id { get; set; }
    	public String Name { get; set; }
    
    	public int CompareTo(Person other) {
    		return Name.CompareTo(other.Name);
    	}
    }
    
    DataGridView dgv = new DataGridView();
    List<Person> pList = new List<Person>();
    BindingSource pSource = new BindingSource();
    public MyForm() {
    	pList.Add(new Person { Id = 1, Name = "Bob" });
    	pList.Add(new Person { Id = 2, Name = "Alan" });
    	pSource.DataSource = pList;
    	dgv.DataSource = pSource;
    
    	FlowLayoutPanel p = new FlowLayoutPanel { Dock = DockStyle.Fill };
    	p.Controls.Add(btn);
    	p.Controls.Add(dgv);
    	Controls.Add(p);
    	btn.Click += btn_Click;
    }
    
    void btn_Click(object sender, EventArgs e) {
    	pList.Sort();
    	dgv.Refresh();
    }
