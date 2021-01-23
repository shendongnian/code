    private void fillTodayPatientsTable()
            {
                string connectionString = "Server=localhost\\sqlexpress;Database=dental;User Id=sa;Password=abc123;";
                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    string id = "";
                    string firstname = "";
                    string lastname = "";
                    string startTime = "";
                    DateTime attendedTime = DateTime.Now;
                    string oString = "Select id,firstname,lastname,start_time,attended_time from Appointments";
                    SqlCommand oCmd = new SqlCommand(oString, myConnection);
                    myConnection.Open();
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        if (oReader.HasRows)
                        {
                            DataTable dttable = new DataTable();
                            DataColumn column;
                           
    
                            column = new DataColumn();
                           // column.DataType = System.Type.GetType("System.Int32");
                            column.DataType = System.Type.GetType("System.String");
                            column.ColumnName = "Firstname";
                            dttable.Columns.Add(column);
    
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = "Lastname";
                            dttable.Columns.Add(column);
    
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = "Start time";
                            column.MaxLength = 200;
                            dttable.Columns.Add(column);
    
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = "Attended time";
                            dttable.Columns.Add(column);
    
                            lbl.ForeColor = Color.Black;
                            lbl.Font = new Font("TimesRoman", 12, FontStyle.Bold);
                            dgStyle.GridColumnStyles.Add(dgLabel);
                            dgLabel.HeaderText = "Label Column";
                            dgLabel.MappingName = "Name";
                            dgLabel.Width = 200;
                            dgStyle.PreferredRowHeight = 24;
    
                            dttable.Columns.Add("Timer");
    
                            col = col = new DataGridViewLabelCellColumn();
    
                            //int counter = 0;
                          
    
                            while (oReader.Read())
                            {
                                id = oReader["id"].ToString();
                                firstname = oReader["firstname"].ToString();
                                lastname = oReader["lastname"].ToString();
                                startTime = oReader["start_time"].ToString();
                                attendedTime = (DateTime) oReader["attended_time"];
                                double attendedTimeStamp= (attendedTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
                                double DateNowTimeStamp = (DateTime.Now - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
                                int waitingTime =(int) (DateNowTimeStamp - attendedTimeStamp);
                               
                                row = dttable.NewRow();
                                row["Firstname"] = firstname;
                                row["Lastname"] = lastname;
                                row["Start time"] = startTime;
                                row["Attended time"] = attendedTime;
                                //row["Timer"] = (counter).ToString();
    
                                TimeSpan t = TimeSpan.FromSeconds(waitingTime);
    
                                string waitingTimeFormatted = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                                                t.Hours,
                                                t.Minutes,
                                                t.Seconds,
                                                t.Milliseconds);
                                row["Timer"] = waitingTimeFormatted;
    
                                dttable.Rows.Add(row);
                                countTest++;
                                                        
                                dgvTodayPatient.DataSource = dttable;
                               
                            }
                        }
                        myConnection.Close();
                       
                    }                           
    
                }
                    
            }        
            private void timer1_Tick(object sender, EventArgs e)
            {
                counter++;
                if (counter == 60 * 60 * 24)
                    timer1.Stop();
               // row["Timer"] = counter.ToString();
                fillTodayPatientsTable();
            }
                 
           
            private void TodayPatient_Load(object sender, EventArgs e)
            {
    
                fillTodayPatientsTable();
                System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
                timer1.Interval = 1000;
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Start();
    
              
            }
