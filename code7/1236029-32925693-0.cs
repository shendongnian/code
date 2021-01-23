    using System;
    using System.Drawing;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Windows.Forms;
     using System.IO;
    using System.Collections.Generic;
    
    class AsyncTcpClient:Form
    {
    
        private TextBox newText;
        private Button check;
        private Label errorMessage;
        public  TcpClient tcpClient;
    
    
       NetworkStream ns;
        StreamReader sr;
        StreamWriter sw;  
        string data;
    
    public AsyncTcpClient()
    {
    tcpClient = new TcpClient("127.0.0.1", 1234);
         ns = tcpClient.GetStream();
        Size = new Size(400, 380);
    
        newText = new TextBox();
        newText.Parent = this;
        newText.Size = new Size(200, 2 * Font.Height);
        newText.Location = new Point(10, 55);
       
        errorMessage = new Label();
        errorMessage.Parent = this;
         errorMessage.Size = new Size(200, 2 * Font.Height);
        errorMessage.Location = new Point(20, 55);   
    
        check = new Button();
         check.Parent = this;
         check.Text = "checkID";
         check.Location = new Point(295, 52);
         check.Size = new Size(6 * Font.Height, 2 * Font.Height);
         check.Click += new EventHandler(checkOnClick);
    
        }
    
    
    void checkOnClick(object obj, EventArgs ea)
    {
        
         using(sr = new StreamReader(ns))
    {
         using(sw = new StreamWriter(ns))
        {
        //sending ID
        sw.WriteLine(newText.Text);
        sw.Flush();
        //receiving validity of ID
        data = sr.ReadLine();
        int validid = int.Parse(data);
        if (validid == 0)
        {            
            newText.Text="Valid data";
            check.Enabled = false;          
        }
        else
        {                        
       errorMessage.Text="InValid data enter again";   
        }
    }
    }
    }
    
    [STAThread]
    public static void Main()
    {
    
        Application.Run(new AsyncTcpClient());
    }
    }
