    sc.Parameters.AddRange(new[]{
       
        new SqlParameter("@Employee1",SqlDbType.VarChar,255){ Value= textBox1.Text},
        new SqlParameter("@Employee2",SqlDbType.VarChar,255){ Value= textBox2.Text},
        new SqlParameter("@Employee3",SqlDbType.VarChar,255){ Value= textBox3.Text},
        new SqlParameter("@Employee4",SqlDbType.VarChar,255){ Value= textBox4.Text},
        new SqlParameter("@Employee5",SqlDbType.VarChar,255){ Value= textBox5.Text}
    
    });
