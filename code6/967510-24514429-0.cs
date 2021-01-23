        if (v != null)
        {
            t1 t = new t1
            {
                Name = TextBox1.Text,
                Age = Convert.ToInt32(TextBox2.Text),
                Address = TextBox3.Text,
                t2 = new t2
                {
                    salary = Convert.ToInt64(TextBox4.Text)
                }
            };
            // de.Entry(t).State = System.Data.Entity.EntityState.Added;
            de.t1.Add(t);
            de.SaveChanges();
        }
