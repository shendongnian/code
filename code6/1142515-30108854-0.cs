    // form1 code
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.SomeChangePropertyEvent += f_SomeChangePropertyEvent;
            f.ShowDialog(this);
        }
        private void f_SomeChangePropertyEvent(bool obj)
        {
            textBox1.Enabled = obj;
        }
    //form2 code
        public event Action<bool> SomeChangePropertyEvent; 
        private void button1_Click(object sender, EventArgs e)
        {
            var h = SomeChangePropertyEvent;
            if (h != null)
                h(false); // I'll set false, you can't something else :)
        }
