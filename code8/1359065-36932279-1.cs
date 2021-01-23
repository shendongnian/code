        private void cal(DataGridView dataGridView1, DataGridView dataGridView2, DataGridView dataGridView3)
        {
            string start_address = Convert.ToString(dataGridView1.Rows[1].Cells[0].Value);
            ///   MessageBox.Show("this is start adder" + start_address);
            for (int i = 1; i < dataGridView1.Rows.Count - 2; i++)
            {
                labelz = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                opcode = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                operand = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                string objcod = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);
                a = a + Convert.ToInt16(3);
                // start_address = Convert.ToString(a);
                string s = a.ToString("X");
                string bv = a.ToString();
                if (dataGridView1.Rows[i].Cells[2].Value.ToString() != "END")
                {
                    if (bv.Length == 2)
                    {
                        string tr = start_address.Remove(1, 2);
                        dataGridView1.Rows[i + 1].Cells[0].Value = tr + s;
                    }
                    else if (bv.Length < 2)
                    {
                        string tr = start_address.Remove(2, 1);
                        dataGridView1.Rows[i + 1].Cells[0].Value = tr + s;
                    }
                }
                d = dataGridView1.Rows[i].Cells[0].Value.ToString();
                if (labelz != null && labelz != "")
                {
                    MessageBox.Show("label is" + labelz + " value is" + d);
                    im(labelz, d);
                    grid2();
                }
                if (opcode != null)
                {
                    for (int kj = 0; kj < dataGridView3.Rows.Count; kj++)
                    {
                        try
                        {
                            if (dataGridView3.Rows[kj].Cells[0].Value.ToString() == opcode)
                            {
                                dataGridView1.Rows[i].Cells[4].Value = dataGridView3.Rows[kj].Cells[1].Value.ToString();
                                value = dataGridView3.Rows[kj].Cells[1].Value.ToString();
                                break;
                            }
                        }
                        catch (Exception e)
                        {
                            string qw = dataGridView1.Rows[i].Cells[3].Value.ToString();
                            if (qw.Length == 4)
                            {
                                value = "00" + qw;
                                dataGridView1.Rows[i].Cells[4].Value = value;
                            }
                            if (qw.Length == 1)
                            {
                                value = "00000" + qw;
                                dataGridView1.Rows[i].Cells[4].Value = value;
                            }
                            if (qw.Length == 2)
                            {
                                value = "0000" + qw;
                                dataGridView1.Rows[i].Cells[4].Value = value;
                            }
                            if (qw.Length == 3)
                            {
                                value = "000" + qw;
                                dataGridView1.Rows[i].Cells[4].Value = value;
                            }
                        }
                    }
                    if (operand != ""&& opcode != "WORD" | opcode != "RESW")
                    {
                       
                        try
                        {
                            for (int jm = 0; jm < dataGridView1.Rows.Count - 1; jm++)
                            {
                                //break;
                                if (dataGridView2.Rows[jm].Cells[0].Value.ToString() == operand)
                                {
                                  
                                    for (int hj = 0; hj < dataGridView1.Rows.Count; hj++)
                                    {
                                        if (dataGridView1.Rows[hj].Cells[1].Value.ToString() == operand)
                                        {
                                           
                                            m = dataGridView1.Rows[hj].Cells[0].Value.ToString();
                                            MessageBox.Show("symbole" + operand + " is already in symbol table" + "with address" + m);
                                            cv(operand,m);
                                            grid2();
                                            break;
                                        }
                                       /* else
                                        {
                                            cv(operand,"XXXX");
                                            grid2();
                                        }*/
                                    }
                                  
                                    
                                }
                            }
                        }
                        catch (NullReferenceException e)
                        {
                            MessageBox.Show("symbol" + operand + "is not present in symbol table & entered with value" + "xxxx");
                            cv(operand, "XXXX");
                            grid2();
                            //break;
                        }
                    }
                    if (operand == "")
                    {
                        dataGridView1.Rows[i].Cells[4].Value = value + "0000";
                    }
                }
                MessageBox.Show("object code is" + dataGridView1.Rows[i].Cells[4].Value.ToString());
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "")
                {
                    for (int jh = 0; jh < dataGridView2.Rows.Count; jh++)
                    {
                        try
                        {
                            if (dataGridView2.Rows[jh].Cells[0].Value.ToString() == operand)
                            {
                               
                                fg = dataGridView2.Rows[jh].Cells[1].Value.ToString();
                              
                                dataGridView1.Rows[i].Cells[4].Value = value + fg;
                                MessageBox.Show(operand);
                                break;
                            }
                        }
                        catch (NullReferenceException v)
                        {
                            break;
                          
                        }
                       
                    }
                }
                for (int mi = 1; mi < dataGridView1.Rows.Count - 2; mi++)
                {
                    if (dataGridView1.Rows[mi].Cells[0].Value.ToString().Length == 3)
                    {
                        string sd = dataGridView1.Rows[mi].Cells[0].Value.ToString();
                        sd = sd.Insert(1, "0");
                        dataGridView1.Rows[mi].Cells[0].Value = sd;
                    }
                    try
                    {
                        string kj = dataGridView1.Rows[mi].Cells[4].Value.ToString();
                        //  MessageBox.Show("kj length is" + kj.Length);
                        if (kj.Length < 6)
                        {
                            for (int re = 0; re < dataGridView2.Rows.Count; re++)
                            {
                                if (dataGridView2.Rows[re].Cells[0].Value.ToString() == dataGridView1.Rows[mi].Cells[3].Value.ToString())
                                {
                                    string vv = dataGridView2.Rows[re].Cells[1].Value.ToString();
                                    dataGridView1.Rows[mi].Cells[4].Value = kj + vv;
                                }
                            }
                        }
                    }
                    catch (NullReferenceException v)
                    {
                    }
                }
            }
        }
        private static void im(string lab, string d)
        {
           
            System.Data.OleDb.OleDbConnection con1 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=D:/ASSEMBLER.mdb");
            try
            {
                con1.Open();
                System.Data.OleDb.OleDbCommand top = new System.Data.OleDb.OleDbCommand(
        "INSERT INTO SYMBOL_TABLE (" +
                "SYMBOLE,ADDRESS" +
            ") VALUES (?,?)", con1);
                top.Parameters.AddWithValue("?", lab);
                top.Parameters.AddWithValue("?", d);
                //  top.Parameters.AddWithValue("?", mcs[2]);
                top.ExecuteNonQuery();
                con1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void cv(string a, string b)
        {
           
            try
            {
                con1.Open();
                System.Data.OleDb.OleDbCommand top1 = new System.Data.OleDb.OleDbCommand("UPDATE SYMBOL_TABLE SET[ADDRESS] = ? where SYMBOLE = ?", con1);
                top1.Parameters.AddWithValue("?", a);
                top1.Parameters.AddWithValue("?", b);
                top1.ExecuteNonQuery();
                con1.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            cal(dataGridView1, dataGridView2, dataGridView3);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
   `
