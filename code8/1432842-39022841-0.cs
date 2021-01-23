     using System;
     using System.Collections.Generic;
     using System.ComponentModel;
     using System.Data;
     using System.Drawing;
     using System.Linq;
     using System.Text;
     using System.Windows.Forms;
     using Emgu.CV;
     using Emgu.CV.Structure;
     using Emgu.Util;
     namespace ImageCapture
     {
    	public partial class Form1 : Form
    	{
    		private Capture capture;        
    		private bool captureInProgress;
    		public Form1()
    		{
    		
    		}
    		
    		private void ProcessFrame(object sender, EventArgs arg)
    		{
    			Image<Bgr, Byte> ImageFrame = capture.QueryFrame();  
    			CamImageBox.Image = ImageFrame;       
            }
    		
    		private void strat_Click(object sender, EventArgs e)
    		{
    			#region if capture is not created, create it now
    			
    			if (capture == null)
    			{
    				try
    				{
    					capture = new Capture();
    				}
    				catch (NullReferenceException excpt)
    				{
    					MessageBox.Show(excpt.Message);
    				}
    			}
    			#endregion
    
    			if (capture != null)
    			{
    				if (captureInProgress)
    				{  
    					btnStart.Text = "Start!"; 
    					Application.Idle -= ProcessFrame;
    				}
    				else
    				{
    					btnStart.Text = "Stop";
    					Application.Idle += ProcessFrame;
    				}
    				captureInProgress = !captureInProgress;
    			} 
    		}
    		
    		private void ReleaseData()
            {
    			if (capture != null)
    				capture.Dispose();
    		}
    	}
     }
