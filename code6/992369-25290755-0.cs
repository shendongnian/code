            string sSQL = "INSERT INTO StuTable (Name, Batch,CGPA, DOB, Program, Picture)VALUES (@Name, @Batch,@CGPA,@DOB,@Program,@Picture)";
            SqlCommand objCmd = new SqlCommand(sSQL, conn);
            objCmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
            objCmd.Parameters.Add("@Batch", SqlDbType.Int);
            objCmd.Parameters.Add("@CGPA", SqlDbType.Float);
            objCmd.Parameters.Add("@DOB", SqlDbType.VarChar, 50);
            objCmd.Parameters.Add("@Program", SqlDbType.VarChar, 50);
            objCmd.Parameters.Add("@Picture", SqlDbType.VarChar, 500);
            //objCmd.Parameters["@RegdNo"].Value = Convert.ToInt32(textBox3.Text);
            objCmd.Parameters["@Name"].Value = textBox4.Text;
            objCmd.Parameters["@Batch"].Value = textBox5.Text;
            objCmd.Parameters["@CGPA"].Value = textBox6.Text;
            objCmd.Parameters["@DOB"].Value = maskedTextBox1.Text;
            objCmd.Parameters["@Program"].Value = textBox8.Text;
            objCmd.Parameters["@Picture"].Value = textBox9.Text;
            objCmd.ExecuteNonQuery();
            //                MessageBox.Show("Record Added");
        }
        catch (Exception te)
        {
            MessageBox.Show(te.Message.ToString());
        }
    }
    }
