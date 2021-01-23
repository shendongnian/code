    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using QuickFix;
    
    namespace FixClientTest
    {
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            public QuickFix.Transport.SocketInitiator _Initiator = null;
    
            private void connectButton_Click(object sender, EventArgs e)
            {
                string file = "c:/FIX/tradeclientIB.cfg";
                try
                {
                    QuickFix.SessionSettings settings = new QuickFix.SessionSettings(file);
                    QuickFix.IApplication myApp = new MyQuickFixApp();
                    QuickFix.IMessageStoreFactory storeFactory = new QuickFix.FileStoreFactory(settings);
                    QuickFix.ILogFactory logFactory = new QuickFix.ScreenLogFactory(settings);
                    //QuickFix.Transport.SocketInitiator initiator = new QuickFix.Transport.SocketInitiator(myApp, storeFactory, settings, logFactory);
                    _Initiator = new QuickFix.Transport.SocketInitiator(myApp, storeFactory, settings, logFactory);
    
                    MyQuickFixApp.UpdateEvent += new MyQuickFixApp.OnUpdateEvent(AddLogItem);
                    _Initiator.Start();
                    
                }
                catch (System.Exception err)
                {
                    Console.WriteLine(err.Message);
                    Console.WriteLine(err.StackTrace);
                    MessageBox.Show(err.ToString());
                }
            }
    
            private void stopButton_Click(object sender, EventArgs e)
            {
                _Initiator.Stop();
            }
            public string stuff;
    
            private delegate void AddLogItemDelegate(string msg);
            public void AddLogItem(string msg)
            {
                if(this.InvokeRequired)
                {
                    this.Invoke(new AddLogItemDelegate(AddLogItem), new object[] { msg });
                    return;
                }
              
                try
                {
                    logListView.Items.Add(msg);
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }
    
        
        public class MyQuickFixApp : QuickFix.IApplication
        {
            
            public delegate void OnUpdateEvent(string msg);
            public static event OnUpdateEvent UpdateEvent;
    
            public void FromApp(QuickFix.Message msg, SessionID sessionID) { }
            public void OnCreate(SessionID sessionID) { }
            public void OnLogout(SessionID sessionID)
            {
                Console.WriteLine("Logged out.");
            }
            public void OnLogon(SessionID sessionID)
            {
                UpdateEvent("STUFF!!");
                Console.WriteLine("Logged In.");
            }
            public void FromAdmin(QuickFix.Message msg, SessionID sessionID)
            {
    
            }
            public void ToAdmin(QuickFix.Message msg, SessionID sessionID) { }
            public void ToApp(QuickFix.Message msg, SessionID sessionID) { }
        }
    
         
    }
