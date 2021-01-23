    try{
            var pic = File.ReadAllBytes(imageName);
            var pic1 = File.ReadAllBytes(imageName1);
            using(OleDbConnection OleDbConn = new OleDbConnection(cs)){
                using(OleDbCommand OleDbComm = new OleDbCommand()){
                    OleDbComm = OleDbConn.CreateCommand();
                    OleDbComm.CommandText = "insert into candidateTB (pollingStationID,"+
                                            "candidateName,candidateCNIC,candidateCell,gender,"+
                                            "candidateEmail,address,description,candidateParty,"+
                                            "candidateImage)  Values ( " + 
                                            "@psid,@cname,@ccnic,@ccell,@gender,@email,@address,"+
                                            "@description,@Photo)";
                    OleDbComm.Parameters.AddWithValue("@psid",textBox2.Text);
                    OleDbComm.Parameters.AddWithValue("@cname",textBox3.Text);
                    OleDbComm.Parameters.AddWithValue("@ccnic",textBox4.Text);
                    OleDbComm.Parameters.AddWithValue("@ccell",textBox5.Text);
                    OleDbComm.Parameters.AddWithValue("@gender",comboBox1.Text);
                    OleDbComm.Parameters.AddWithValue("@email",comboBox6.Text);
                    OleDbComm.Parameters.AddWithValue("@address",textBox7.Text);
                    OleDbComm.Parameters.AddWithValue("@description",textBox8.Text);
                    OleDbComm.Parameters.AddWithValue("@description",comboBox5.Text);
                    OleDbComm.Parameters.AddWithValue("@Photo",pic);
                    //OleDbComm.Parameters.AddWithValue("@Photo1",pic1); I don't from where it came, I don't see in the insert query.
                    OleDbConn.Open();
                    int x = OleDbComm.ExecuteNonQuery();
                    //OleDbConn.Close(); you don't need to close it, when the end of using statement is executed it will automatically close & dispose it.
                    MessageBox.Show(x.ToString() + ": Record is Successfully Inserted");
               }
           }
    }
    catch (Exception ex){
         MessageBox.Show(ex.Message);
    }
