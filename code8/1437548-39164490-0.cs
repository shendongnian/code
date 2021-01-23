    // You can use auto-property in here.
    private Form2 frm2 { get; set; }
    
    private void button1_Click(object sender, EventArgs e)
    {
        // Create a new instance before it is shown.
        NewForm();
        frm2.Show();
    }
    
    // Creates a new instance and hooks the event.
    private void NewForm()
    {
        frm2 = new Form2();
        // When creating an instance, hook the load event.
        frm2.Load += Form2_Load;
    }
    
    // Will be triggered when show is called.
    private void Form2_Load(object sender, EventArgs e)
    {
        // Do stuff
    }
