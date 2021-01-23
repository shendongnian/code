        List<Person> lst = new List<Person>();
        private void button5_Click(object sender, EventArgs e)
        {
           
            lst.Add(new Person("X"));
            lst.Add(new Person("y"));
            dataGridView2.DataSource = lst;
            
            lst.Add(new Person("Z"));
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = lst;
        }
     public class Person
        {
            public Person(string fname)
            {
                this.firstname = fname;
            }
            public string firstname { get; set; }
        }
