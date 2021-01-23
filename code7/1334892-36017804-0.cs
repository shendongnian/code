    protected void go_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;
            string Name = name.Text;
            Debug.WriteLine(string.Format("name = {0}", Name)); //X
       }
