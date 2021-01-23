    public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();
    /********************************************************************************************************************************************
     * Before you refer to this demo,we strongly suggest you read the development manual deeply first.                                           *
     * This part is for demonstrating the communication with your device.There are 3 communication ways: "TCP/IP","Serial Port" and "USB Client".*
     * The communication way which you can use duing to the model of the device.                                                                 *
     * *******************************************************************************************************************************************/
    #region Communication
    private bool bIsConnected = false;//the boolean value identifies whether the device is connected
    private int iMachineNumber = 1;//the serial number of the device.After connecting the device ,this value will be changed.
    //If your device supports the TCP/IP communications, you can refer to this.
    //when you are using the tcp/ip communication,you can distinguish different devices by their IP address.
    private void btnConnect_Click(object sender, EventArgs e, string ip)
    {
            
        if (ip == "")
        {
            MessageBox.Show("IP and Port cannot be null", "Error");
            return;
        }
        int idwErrorCode = 0;
        Cursor = Cursors.WaitCursor;
        if (btnConnect.Text == "DisConnect")
        {
            axCZKEM1.Disconnect();
            bIsConnected = false;
            btnConnect.Text = "Connect";
            lblState.Text = "Current State:DisConnected";
            Cursor = Cursors.Default;
            return;
        }
        bIsConnected = axCZKEM1.Connect_Net(ip, Convert.ToInt32(txtPort.Text));
        if (bIsConnected == true)
        {
            btnConnect.Text = "DisConnect";
            btnConnect.Refresh();
            lblState.Text = "Current State:Connected";
            iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
            axCZKEM1.RegEvent(iMachineNumber, 65535);//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
        }
        else
        {
            axCZKEM1.GetLastError(ref idwErrorCode);
            MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
        }
        Cursor = Cursors.Default;
    }
    //Download the attendance records from the device(For both Black&White and TFT screen devices).
    private void btnGetGeneralLogData_Click(object sender, EventArgs e)
    {
        if (bIsConnected == false)
        {
            MessageBox.Show("Please connect the device first", "Error");
            return;
        }
        string sdwEnrollNumber = "";
        int idwTMachineNumber=0;
        int idwEMachineNumber=0;
        int idwVerifyMode=0;
        int idwInOutMode=0;
        int idwYear=0;
        int idwMonth=0;
        int idwDay=0;
        int idwHour=0;
        int idwMinute=0;
        int idwSecond = 0;
        int idwWorkcode = 0;
           
        int idwErrorCode=0;
        int iGLCount = 0;
        int iIndex = 0;
        Cursor = Cursors.WaitCursor;
        lvLogs.Items.Clear();
        axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device
        if (axCZKEM1.ReadGeneralLogData(iMachineNumber))//read all the attendance records to the memory
                
        {
            while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
                       out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
            {
                iGLCount++;
                lvLogs.Items.Add(iGLCount.ToString());
                lvLogs.Items[iIndex].SubItems.Add(sdwEnrollNumber);//modify by Darcy on Nov.26 2009
                lvLogs.Items[iIndex].SubItems.Add(idwVerifyMode.ToString());
                lvLogs.Items[iIndex].SubItems.Add(idwInOutMode.ToString());
                lvLogs.Items[iIndex].SubItems.Add(idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSecond.ToString());
                lvLogs.Items[iIndex].SubItems.Add(idwWorkcode.ToString());
                iIndex++;
            }
        }
        else
        {
            Cursor = Cursors.Default;
            axCZKEM1.GetLastError(ref idwErrorCode);
            if (idwErrorCode != 0)
            {
                MessageBox.Show("Reading data from terminal failed,ErrorCode: " + idwErrorCode.ToString(),"Error");
            }
            else
            {
                MessageBox.Show("No data from terminal returns!","Error");
            }
        }
        axCZKEM1.EnableDevice(iMachineNumber, true);//enable the device
        Cursor = Cursors.Default;
    }
