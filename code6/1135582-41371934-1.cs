    private static Capture _cameraCapture;
    //Windows form button to start the video stream                
    private void btn_play_Click(object sender, EventArgs e)
    {            
     Run();                            
    } 
                  
    private void Run()
    {
     if (rdbWebcam.Checked == true) //radio button
     {
      _cameraCapture = new Capture(0); //use local webcam
     }
    else
      {
      _cameraCapture = new Capture(txtrtsp.Text); //use rtsp or http uri you typed into a textbox
      }
     Application.Idle += ProcessFrame;
    }   
                
    private void  ProcessFrame(object sender, EventArgs e)
     {         
       try
           {
            Mat frame = _cameraCapture.QueryFrame();
            imageBox1.Image = frame; //imagebox to  show live video
            }
           catch (Exception ex)
            {
            MessageBox.Show(ex.Message);
             Application.Exit();
             }
    }
            
    //Windows Form FormClosing event
    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {     
     if (_cameraCapture != null)
        {
         _cameraCapture.Stop();
         _cameraCapture.Dispose();
        }
                      
    }
