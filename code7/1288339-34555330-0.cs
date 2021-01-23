    private string StrValue = "";
    private void Port_DataReceived(object sender, 
    System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        double DouRWeight = 0;    
        try
        {
            DouRWeight = Val.ToDouble(Port.ReadLine());
            if (DouRWeight != 0)
            {
                 this.Invoke((System.Windows.Forms.MethodInvoker)delegate()
                 {
                     StrValue   = Val.Format(DouRWeight.ToString(), "####0.000");
			     }
		    }
	    }
	}
    private void button1_Click(object sender, EventArgs e)
    {
            richTextBox1.WordWrap = true;
            richTextBox1.Text = StrValue ;
    }
