        private void Form1_Load(object sender, EventArgs e)
        {
            list1 = new List<Person>();
            using (SportsClubEntities spe = new SportsClubEntities())
            {
                list1 = (from p in spe.People
                          select p).ToList();
            }
            bs = new BindingSource();
            bs.DataSource = list1;
            listBox1.DataSource = bs;
            listBox1.DisplayMember = "FirstName";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Person p1 = (Person)listBox1.SelectedItem;
            list1.Remove((Person)listBox1.SelectedItem);
            bs.ResetBindings(false);
            using (SportsClubEntities spe = new SportsClubEntities())
            {
                Person p2 = (from p in spe.People
                         where p.BusinessEntityID == p1.BusinessEntityID
                         select p).FirstOrDefault();
                spe.People.Remove(p2);
                spe.SaveChanges();
            }
        }
