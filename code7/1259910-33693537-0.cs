    public partial class Form1 : Form
        {
            List<List<object>> function;
            List<object> useCase;
    
            public Form1()
            {
                function = new List<List<object>>();
                useCase =new List<object>();
    
                InitializeComponent();
    
    
                useCase.AddRange(new object[] {
                "List0Item0",
                "List0Item1",
                "List0Item2",
                "List0Item3",
                "List0Item4",
                "List0Item5"});
    
                this.function.Add(this.useCase);
    
                this.checkedListBox1.Items.Add(function);
    
                useCase = new List<object>();
                useCase.AddRange(new object[] {
                "List1Item0",
                "List1Item1",
                "List1Item2",
                "List1Item3",
                "List1Item4",
                "List1Item5"});
    
                this.function.Add(this.useCase);
    
                this.checkedListBox1.Items.Add(function);
    
    
            }
    
            private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                this.checkedListBox2.Items.Clear();
                for (int i = 0; i < this.function.Count(); i++)
                {
                    if (checkedListBox1.SelectedIndex == i)
                    {
                        for (int j = 0; j < this.function[i].Count(); j++)
                        {
                            this.checkedListBox2.Items.Add(this.function[i][j]);
                        }
                    }
                }
            }
        }
