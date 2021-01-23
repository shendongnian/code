       private static Capture _cameraCapture;
             private void btn_play_Click(object sender, EventArgs e)
            {            
                    Run();                            
            } 
          private void Run()
                {
                        if (rdbWebcam.Checked == true)
                        {
                            _cameraCapture = new Capture(0); //use local webcam
                        }
                        else
                        {
                            _cameraCapture = new Capture(txtrtsp.Text); //use rtsp or http uri
                        }
                 
                        Application.Idle += ProcessFrame;
        
                            
                }   
        
        
           private void  ProcessFrame(object sender, EventArgs e)
                {         
                        try
                        {
                            Mat frame = _cameraCapture.QueryFrame();
                            imageBox1.Image = frame;
                        }
                        
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Application.Exit();
                    }
                }
    
            private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
            {     
                if (_cameraCapture != null)
                {
                    _cameraCapture.Stop();
                    _cameraCapture.Dispose();
                }
              
            }
