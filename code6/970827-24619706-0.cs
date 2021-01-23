    class ListItem
    {
    public string DisplayMember;
    public string ValueMember;
     public ListItem(string n,string v){
         DisplayMember = n;
         ValueMember = v;
     }
}
    public CompareTimeFramesForm()
    {
        InitializeComponent();           
        listBox1.Items.Add(new ListItem("# of Bookings", null).DisplayMember);
        listBox1.Items.Add(new ListItem("People", "guaranteed_count").DisplayMember);
    }
