        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string xml = @"<NewDataSet>
                          <Table1>
                            <ID>AN ID</ID>
                            <Name>A NAME</Name>
                          </Table1>
                          <Table1>
                            <ID>ANOTHER ID</ID>
                            <Name>ANOTHER NAME</Name>
                          </Table1>
                          <Table1>
                             <ID>YET ANOTHER ID AND SO ON</ID>
                             <Name>YET ANOTHER NAME AND SO ON</Name>
                            <Bonus>Bonus Column</Bonus>
                          </Table1>
                        </NewDataSet>";
            using (DataSet ds = new DataSet())
            {
                using (MemoryStream mStrm = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                {
                    ds.ReadXml(mStrm);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }
