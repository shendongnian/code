        private void setDataSource(BindingList<ListObject> list)
            {
              if(list!=null)
               {
                if(this.dataGridView1.InvokeRequired)
                {
                    SetDSCallback method = new SetDSCallback(this.setDataSource);
                    base.Invoke(method, new object[] { list }); <-- Error Here
                }
                else
                {
                    this.dataGridView1.DataSource = null;
                    this.dataGridView1.DataSource = list;
                    this.dataGridView1.Columns["ip"].HeaderText = "External IP";
                    this.dataGridView1.Columns["macAddress"].HeaderText = "MAC Address";
                    this.dataGridView1.Columns["ipSource"].HeaderText = "IP Source";
                    this.dataGridView1.Columns["ipDest"].HeaderText = "IP Destination";
                    this.dataGridView1.Columns["portSource"].HeaderText = "Source Port";
                    this.dataGridView1.Columns["portDest"].HeaderText = "Destination Port";
                    this.dataGridView1.Columns["protocol"].HeaderText = "Protocol";
                    this.dataGridView1.Columns["label"].HeaderText = "Label";
                    this.dataGridView1.Columns["country"].HeaderText = "Country";
                    this.dataGridView1.Columns["state"].HeaderText = "State";
                    this.dataGridView1.Columns["city"].HeaderText = "City";
                    this.dataGridView1.Columns["packetCount"].HeaderText = "Packets";
                }
             }
             else
             {
              //handle if list is null
             }
            }
