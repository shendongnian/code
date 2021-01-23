    var textBoxes = new List<TextBox> { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };
    using(var conn = new SqlConnection("Connectionstring"))
    using (StreamReader sr = new StreamReader(@"saverisbex"))
    {
        int lineNumber = 0;
        int lastGroup = 0;
        string line;
        conn.Open(); // before the loop not in loop
        while((line = sr.ReadLine()) != null)
        {
            int currentGroup = lineNumber / 8;
            if (lastGroup != currentGroup)
            {
                // presuming that ID is the primary key and an identity column which auto generates its value on insert
                string insertSQL = @"insert into finabex (home,away,homescoresft,awayscoresft, oddhome,oddx,oddaway,date) 
                                     values (@home,@away,@homescoresft,@awayscoresft,@oddhome,@oddx,@oddaway,@date)";
                using (var comando = new SqlCommand(insertSQL, conn))
                {
                    comando.Parameters.Add("@home", SqlDbType.VarChar).Value = textBox9.Text;
                    comando.Parameters.Add("@away", SqlDbType.VarChar).Value = textBox1.Text;
                    comando.Parameters.Add("@homescoresft", SqlDbType.VarChar).Value = textBox2.Text;
                    comando.Parameters.Add("@awayscoresft", SqlDbType.VarChar).Value = textBox3.Text;
                    comando.Parameters.Add("@oddhome", SqlDbType.VarChar).Value = textBox4.Text;
                    comando.Parameters.Add("@oddx", SqlDbType.VarChar).Value = textBox5.Text;
                    comando.Parameters.Add("@oddaway", SqlDbType.VarChar).Value = textBox7.Text;
                    DateTime date;
                    if (!DateTime.TryParse(textBox8.Text, out date))
                    {
                        MessageBox.Show("Not a valid date: " + textBox8.Text);
                        continue;
                    }
                    comando.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
                    int insertedCount = comando.ExecuteNonQuery();
                }
                // ...
            }
            int textBoxNumber = lineNumber % 8;
            textBoxes[textBoxNumber].Text = line;
            // ...
            lastGroup = currentGroup;
            lineNumber++;
        }
    }
