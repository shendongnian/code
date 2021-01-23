          bool isConnected;
            try {
                isConnected = zkem.Connect_Net(ipAddr.Text, Convert.ToInt32(4370));
            } catch (Exception ext) {
                Debug.WriteLine("Холбогдож чадсангүй" + ext);
                zkem.GetLastError(ref idwErrorCode);
                if (idwErrorCode != 0) {
                    getError(idwErrorCode);
                } else {
                    MessageBox.Show("No data from terminal returns!", "Error");
                }
                throw new Exception();
            }
            if (isConnected) { //Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                this.btnRC.Enabled = false;
                zkem.EnableDevice(1, true);
                zkem.RegEvent(1, 65535);
                this.zkem.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(onAttTransactionEx);
                string sdwEnrollNumber = "";
                int idwVerifyMode = 0;
                int idwInOutMode = 0;
                int idwYear = 0;
                int idwMonth = 0;
                int idwDay = 0;
                int idwHour = 0;
                int idwMinute = 0;
                int idwSecond = 0;
                int idwWorkcode = 0;
                Cursor = Cursors.WaitCursor;
                zkem.EnableDevice(1, false);//disable the device
                if (zkem.ReadGeneralLogData(1)) { //read all the attendance records to the memory
                    Debug.WriteLine("Trying to open connection");
                    m_dbConnection.Open();
                    Debug.WriteLine("Connection Opened");
                    using (var command = new SQLiteCommand(m_dbConnection)) {
                        using (var transaction = m_dbConnection.BeginTransaction()) {
                            command.CommandText = String.Format("INSERT INTO `{0}` (`state`, `user_id`, `date`) VALUES(@state, @userID, @date)", prefix);
                            command.Prepare();
                            while (zkem.SSR_GetGeneralLogData(1, out sdwEnrollNumber, out idwVerifyMode,
                                    out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour,
                                    out idwMinute, out idwSecond, ref idwWorkcode)) { //get records from the memory
                                DateTime datetime = new DateTime(idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond);
                                int unixDate = (Int32)(datetime.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                                try {
                                    command.Parameters.AddWithValue("@state", idwInOutMode);
                                    command.Parameters.AddWithValue("@userID", Convert.ToInt32(sdwEnrollNumber));
                                    command.Parameters.AddWithValue("@date", unixDate);
                                } catch (Exception ex) {
                                    //Debug.WriteLine(ex.ToString() + Environment.NewLine + ex.StackTrace);
                                }
                                try {
                                    command.ExecuteNonQuery();
                                    Debug.WriteLine("inserted: " + String.Format("{0}/{1}/{2} {3}:{4}:{5}.000", idwYear , idwMonth, idwDay, idwHour, idwMinute, idwSecond));
                                } catch (SQLiteException ex) {
                                    Debug.WriteLine(ex.ToString() +  " "+ex.StackTrace);
                                }
                            }
                            transaction.Commit();
                        }
                    }
                    m_dbConnection.Close();
                    Debug.WriteLine("Connection Closed");
                    Cursor = Cursors.Default;
                } else {
                    Cursor = Cursors.Default;
                    zkem.GetLastError(ref idwErrorCode);
                    if (idwErrorCode != 0) {
                        getError(idwErrorCode);
                    } else {
                        MessageBox.Show("No data from terminal returns!", "Error");
                    }
                }
                zkem.EnableDevice(1, true); //enable the device
                Cursor = Cursors.Default;
                logBox.Items.Add("Холбогдлоо");
            }  
