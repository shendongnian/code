    public zkemkeeper.CZKEM zkemKeeper = new zkemkeeper.CZKEM();//initializing dll
   
    private bool bIsConnected = false;//the boolean value identifies whether the device is connected
    //Initializing bisconnected to connect the device
    bool bIsConnected = zkemKeeper.Connect_Net(txtip.Text, Convert.ToInt32(txtport.Text));
     private void btnDownLoadFace_Click(object sender, EventArgs e)
        {
        string sUserID = "";
        string sName = "";
        string sPassword = "";
        int iPrivilege = 0;
        bool bEnabled = false;
        int iFaceIndex = 50;//the only possible parameter value
        string sTmpData = "";
        int iLength = 0;
        zkemKeeper.EnableDevice(iMachineNumber, false);
            zkemKeeper.ReadAllUserID(iMachineNumber);//read all the user information to the memory
            while (zkemKeeper.SSR_GetAllUserInfo(iMachineNumber, out sUserID, out sName, out sPassword, out iPrivilege, out bEnabled))//get all the users' information from the memory
            {
                if (zkemKeeper.GetUserFaceStr(iMachineNumber, sUserID, iFaceIndex, ref sTmpData, ref iLength))//get the face templates from the memory
                {
                    //save whatever data you want for eg:
                   ListViewItem list = new ListViewItem();
                    list.Text = sUserID;
                    list.SubItems.Add(sName);
                    list.SubItems.Add(sPassword);
                    list.SubItems.Add(iPrivilege.ToString());
                    list.SubItems.Add(iFaceIndex.ToString());
                    list.SubItems.Add(sTmpData);
                    list.SubItems.Add(iLength.ToString());
                    if (bEnabled == true)
                    {
                        list.SubItems.Add("true");
                    }
                    else
                    {
                        list.SubItems.Add("false");
                    }
                    lvFace.Items.Add(list);//lv Face is a List View 
                }
            }
     zkemKeeper.EnableDevice(iMachineNumber, true);
    }
