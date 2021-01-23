    // Replace list of person with your MaterijaliGrid object
    var list = new List<Person>();
    list.Add(new Person { FirstName = "Robert", Initial = "Santos", LastName = "Lee" });
    list.Add(new Person { FirstName = "Robert1", Initial = "Santos1", LastName = "Lee1" });
    list.Add(new Person { FirstName = "Robert2", Initial = "Santos2", LastName = "Lee2" });
    list.Add(new Person { FirstName = "Robert3", Initial = "Santos3", LastName = "Lee3" });
     
    // You can hide row header if don't want it.  
    dataGridView1.RowHeadersVisible = false;    
    dataGridView1.AutoGenerateColumns = true;
    dataGridView1.AutoSize = true;            
    dataGridView1.DataSource = list;
