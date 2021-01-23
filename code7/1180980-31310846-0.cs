                int index = dataGridView1.Rows.Count;
                RDP0 newefes = new EFESRDP0();
                newefes.NO = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                newefes.CUSTID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                
                newefes.IPADDRESS = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                newefes.USER = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);                
                db.RDP0s.InsertOnSubmit(newefes);
                db.SubmitChanges();
