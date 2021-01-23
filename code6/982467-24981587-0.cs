    bool exitThread;
    
    private void Form1_Load(object sender, EventArgs e)
    {
    
        t = new Thread(new ThreadStart(serialcek));
        CheckForIllegalCrossThreadCalls = false;
        exitThread = false;
        t.Start();
      }
    
    public void serialcek()
    {
    
        ManagementObjectSearcher theSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");
        while (! exitThread)
        {
            try
            {
                foreach (ManagementObject currentObject in theSearcher.Get())
                {
                    ManagementObject theSerialNumberObjectQuery = new ManagementObject("Win32_PhysicalMedia.Tag='" + currentObject["DeviceID"] + "'");
                    try
                    {
                        serial = theSerialNumberObjectQuery["SerialNumber"].ToString();
                        textBox1.Text = serial;
                    }
                    catch (Exception)
                    {
                        // MessageBox.Show("Bişiler oldu bende anlamadım");
        
                    }
    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Patladım ben." + ex.Message.ToString());
            }
            finally
            {
                // Moved Sleep into 'finally' block to make it be called even if an exception occurs
                Thread.Sleep(sure);
        }    
    }
