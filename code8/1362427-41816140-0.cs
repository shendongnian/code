    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using zkemkeeper;
    using System.IO;
    using System.Threading;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            string filePath = @"E:\file1.txt";
            bool connSatus = false;
            CZKEMClass axCZKEM1,axCZKEM2;
            public Form1(){
                InitializeComponent();}
            private void Form1_Load(object sender, EventArgs e){
                Thread createComAndMessagePumpThread = new Thread(() =>
                {
                    axCZKEM1 = new CZKEMClass();
                    connSatus = axCZKEM1.Connect_Net("162.36.2.24", 4370);
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine("HR Machine is connected  at the" + "Date :" + DateTime.Now.ToString() + "status" + connSatus);
                        writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                    }
                    if (connSatus == true)
                    {
                        axCZKEM1.OnVerify -= new _IZKEMEvents_OnVerifyEventHandler(OnVerify);
                        axCZKEM1.OnConnected -= new _IZKEMEvents_OnConnectedEventHandler(OnConnected);
                        axCZKEM1.OnAttTransaction -= new _IZKEMEvents_OnAttTransactionEventHandler(OnAttTransaction);
                        axCZKEM1.OnAttTransactionEx -= new _IZKEMEvents_OnAttTransactionExEventHandler(OnAttTransactionEx);
                        axCZKEM1.OnDisConnected -= new _IZKEMEvents_OnDisConnectedEventHandler(OnDisConnected);
                        if (axCZKEM1.RegEvent(1, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                        {
                            axCZKEM1.OnVerify += new _IZKEMEvents_OnVerifyEventHandler(OnVerify);
                            axCZKEM1.OnAttTransactionEx += new _IZKEMEvents_OnAttTransactionExEventHandler(OnAttTransactionEx2;
                            axCZKEM1.OnAttTransaction += new _IZKEMEvents_OnAttTransactionEventHandler(OnAttTransaction);
                            axCZKEM1.OnConnected += new _IZKEMEvents_OnConnectedEventHandler(OnConnected);
                            axCZKEM1.OnDisConnected += new _IZKEMEvents_OnDisConnectedEventHandler(OnDisConnected);
                            using (StreamWriter writer = new StreamWriter(filePath, true))
                            {
                                writer.WriteLine("attendnce transaction Events are registered... ");
                                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                            }
                        }
                    }
                    Application.Run();
                });
                createComAndMessagePumpThread.SetApartmentState(ApartmentState.STA);
                createComAndMessagePumpThread.Start();
                Thread createComAndMessagePumpThread = new Thread(() =>
                {
                    axCZKEM2 = new CZKEMClass();
                    connSatus = axCZKEM2.Connect_Net("162.36.2.22", 4370);
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine("HR Machine is connected  at the" + "Date :" + DateTime.Now.ToString() + "status" + connSatus);
                        writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                    }
                    if (connSatus == true)
                    {
                        axCZKEM2.OnVerify -= new _IZKEMEvents_OnVerifyEventHandler(OnVerify);
                        axCZKEM2.OnConnected -= new _IZKEMEvents_OnConnectedEventHandler(OnConnected);
                        axCZKEM2.OnAttTransaction -= new _IZKEMEvents_OnAttTransactionEventHandler(OnAttTransaction);
                        axCZKEM2.OnAttTransactionEx -= new _IZKEMEvents_OnAttTransactionExEventHandler(OnAttTransactionEx);
                        axCZKEM2.OnDisConnected -= new _IZKEMEvents_OnDisConnectedEventHandler(OnDisConnected);
                        if (axCZKEM2.RegEvent(1, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                        {
                            axCZKEM2.OnVerify += new _IZKEMEvents_OnVerifyEventHandler(OnVerify);
                            axCZKEM2.OnAttTransactionEx += new _IZKEMEvents_OnAttTransactionExEventHandler(OnAttTransactionEx2;
                            axCZKEM2.OnAttTransaction += new _IZKEMEvents_OnAttTransactionEventHandler(OnAttTransaction);
                            axCZKEM2.OnConnected += new _IZKEMEvents_OnConnectedEventHandler(OnConnected);
                            axCZKEM2.OnDisConnected += new _IZKEMEvents_OnDisConnectedEventHandler(OnDisConnected);
                            using (StreamWriter writer = new StreamWriter(filePath, true))
                            {
                                writer.WriteLine("attendnce transaction Events are registered... ");
                                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                            }
                        }
                    }
                    Application.Run();
                });
                createComAndMessagePumpThread.SetApartmentState(ApartmentState.STA);
                createComAndMessagePumpThread.Start();}
            private void OnDisConnected(){
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Machine is disconnected");
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }}
            private void OnAttTransactionEx(string sEnrollNumber, int iIsInValid, int iAttState, int iVerifyMethod, int iYear, int iMonth, int iDay, int iHour, int iMinute, int iSecond, int iWorkCode){
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(" OnAttTrasactionEx Has been Triggered,Verified OK on" + "Date :" + "Enrollnumber" + sEnrollNumber + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }}
            private void OnConnected(){
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(" machine connected event is triggered sucessfully.");
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }}
            private void OnVerify(int iUserID){
                if (iUserID != -1)
                {
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine(" User is veified sucessfully.");
                        writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                    }
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine(" User is not veified sucessfully.");
                        writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                    }
                }}
            private void OnAttTransaction(int iEnrollNumber, int iIsInValid, int iAttState, int iVerifyMethod, int iYear, int iMonth, int iDay, int iHour, int iMinute, int iSecond){
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(" OnAttTrasaction Has been Triggered,Verified OK on" + "Date :" + "Enrollnumber" + iEnrollNumber + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
        }
    }
