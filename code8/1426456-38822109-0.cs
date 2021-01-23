        private void button1_Click(object sender, EventArgs e)
        {
            classA A = new classA("test");
            classB B = new classB();
    
            foreach (var field in A.GetType().GetProperties())
            {
                PropertyInfo pi = B.GetType().GetProperty(field.Name);
                pi.SetValue(B, field.GetValue(A, null));
            }
    
        }
    
    public class classA{
        public string name { get; set; }
    
        public classA(string name)
        {
            this.name = name;
        }
    }
    
    public class classB
    {
        public string name { get; set; }
    }
