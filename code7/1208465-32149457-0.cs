        private void Form1_Load(object sender, EventArgs e)
        {
            list1 = new List<Person>();
            using (SportsClubEntities spe = new SportsClubEntities())
            {
                list1 = (from p in spe.People
                          where p.PersonType == "EM"
                          select p).ToList();
            }
            bs = new BindingSource();
            bs.DataSource = list1;
            listBox1.DataSource = bs;
            listBox1.DisplayMember = "FirstName";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            list1.Remove((Person)listBox1.SelectedItem);
            bs.ResetBindings(false);
        }
