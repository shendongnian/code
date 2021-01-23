    **[WebMethod]**
    public static void SaveMeetingShechudar(string MDate, string MTime, int MPurpose, int masterID, int RowNumber, string[] name, string[] nic, string[] designation, string[] company, string[] address)
    {
        int mID = 0;
         try
            {
            #region master part save
            MeetingSchedulMaster master = new MeetingSchedulMaster();
            master.m_date = Convert.ToDateTime(MDate);
            master.m_datetime = MTime;
            master.m_host = UserID;
            master.m_puposeid = Convert.ToInt32(MPurpose);
            master.m_entry_date = DateTime.Now;
            if (masterID == 0)
                saveDataMaster(master);
            else
            {
                master.mid = masterID;
                UpdateData(master);
            }
            #endregion
            #region detail part save
            if (MasterIDForUpdation == 0)
                mID = GetMaxMeetinNumber_ID("2");
            else
                mID = masterID;
            for (int i = 1; i <= RowNumber; i++)
            {
                MeetingSchedulDetail detail = new MeetingSchedulDetail();
                //TableRow row = tbladdnewmeeting.Rows[i-1];
                detail.name = name[i];
                detail.cnic = nic[i];
                detail.designation = designation[i];
                detail.company = company[i];
                detail.address = address[i];
                detail.mid = mID;
                saveDataDetail(detail);
            }
        }
        catch (Exception e) { }
  }
