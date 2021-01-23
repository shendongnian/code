    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Oracle.ManagedDataAccess.Client;
    namespace TimeoutTest
    {
      public partial class Form1 : Form
      {
        List<TestConnection> connections;
        Int32 connectionCount;
        Int32 multiplier;
        Int32 initialConnectionWait;
    
        TestConnection controlConnection = null;
    
        public Form1()
        {
          InitializeComponent();
    
    
    
        }
    
        private void BtStart_Click(object sender, EventArgs e)
        {
    
          connectionCount = Int32.Parse(InConnections.Text);
          multiplier = Int32.Parse(InMultiplier.Text);
          initialConnectionWait = Int32.Parse(InInitialWait.Text);
    
          DisplayMessage("Starting control connection\r\n");
          controlConnection = new TestConnection();
          controlConnection.ErrorOccured += new EventHandler(controlConnection_ErrorOccured);
          controlConnection.IsControlConnection = true;
          controlConnection.StartTest(2);
    
          connections = new List<TestConnection>();
          DisplayMessage("Spinning up {0} connections...\r\n", connectionCount);
          for (int i = 0, idleTime=initialConnectionWait; i < connectionCount; i++, idleTime*=multiplier)
          {
    
            TestConnection connection = new TestConnection();
            connection.Notified += new TestConnection.NotificationEventHandler(connection_Notified);
            connection.ErrorOccured += new EventHandler(connection_ErrorOccured);
            connection.TestCompleted += new EventHandler(connection_TestCompleted);
            connection.StartTest(idleTime);
    
            connections.Add(connection);
          }
          DisplayMessage("");
        }
    
    
        void controlConnection_ErrorOccured(object sender, EventArgs e)
        {
          DisplayMessage("\r\nControl connection error, aborting!!!");
          BtCancel_Click(this, EventArgs.Empty);
    
        }
    
        void connection_TestCompleted(object sender, EventArgs e)
        {
          TestConnection currentConnection = (TestConnection)sender;
          
          if (currentConnection == connections.Last())
            DisplayMessage("\r\nAll tests complete.  Done");
          
        }
    
        void connection_ErrorOccured(object sender, EventArgs e)
        {
          //stop any active connection.
          foreach(TestConnection tc in connections)
          {
            tc.CompletionTimer.Enabled=false;
          }
    
          TestConnection currentConnection = (TestConnection)sender;
          Int32 upperTime = currentConnection.IdleTime;
          Int32 lowerTime = 0;
          
          Int32 index = connections.IndexOf(currentConnection);
          //if this is not the first connection...
          if(index > 0)
          {
            //...then set the lower time based on the previous connection
            lowerTime = connections[index-1].IdleTime;
          }
    
          //get the difference between the lower and upper as the new range to work on
          Int32 range = upperTime - lowerTime;
    
          
          //divide the range over the number of connections to get the new interval
          Int32 interval = range / this.connectionCount;
          connections.Clear();
    
          //if the interval is too small try to reduce the number of connections
          while (interval < 2 && this.connectionCount > 2)
          {
            this.connectionCount--;
            DisplayMessage("\r\nConnections too high for current resolution.  Reducing to {0} connections.", this.connectionCount);
            interval = range / this.connectionCount;
          }
    
    
    
          if(interval < 2)
          {
            DisplayMessage("\r\nResolution cannot be increased.  Done.");
          }
          else
          {
            DisplayMessage("\r\nRestarting test with min:{0}, max{1}, resolution{2}.", lowerTime, upperTime, interval);
    
    
            //create the new connections
            for (int i = connectionCount-1, idleTime = upperTime-interval; i >= 0; i--, idleTime-=interval)
            {
    
              TestConnection connection = new TestConnection();
              connection.Notified += new TestConnection.NotificationEventHandler(connection_Notified);
              connection.ErrorOccured += new EventHandler(connection_ErrorOccured);
              connection.TestCompleted += new EventHandler(connection_TestCompleted);
              connection.StartTest(idleTime);
    
              connections.Insert(0,connection);
            }
            this.connectionCount = connections.Count;
          }
    
        }
        private void BtCancel_Click(object sender, EventArgs e)
        {
          //stop any active connection.
          foreach (TestConnection tc in connections)
          {
            tc.CompletionTimer.Enabled = false;
            tc.Command.Connection.Close();
          }
          DisplayMessage("Stopped running tests.");
        }
    
    
        void connection_Notified(object o, Form1.TestConnection.NotificationEventArgs e)
        {
          DisplayMessage(e.Message);
        }
    
        private void DisplayMessage(String message)
        {
          DisplayMessage("{0}", message);
        }
        private void DisplayMessage(String message, params Object[] args)
        {
          OutStatus.AppendText(String.Format(message, args) + "\r\n");
        }
        
    
        public class TestConnection
        {
          public Boolean IsControlConnection { get; set; }
          public OracleCommand Command { get; private set; }
          public Timer CompletionTimer { get; private set; }
          public String ConnectionId { get; private set; }
          public Int32 IdleTime
          {
            get
            {
              return CompletionTimer.Interval / 1000;
            }
            set
            {
              CompletionTimer.Interval = value * 1000;
            }
          }
          #region Events and Delegates
          public event EventHandler ErrorOccured;
          public event EventHandler TestCompleted;
          public class NotificationEventArgs : EventArgs
          {
            public NotificationEventArgs(String message)
            {
              this.Message = message;
            }
            public String Message { get; set; }
          }
    
          public delegate void NotificationEventHandler(object o, NotificationEventArgs e);
    
          public event NotificationEventHandler Notified;
    
          private void Notify(String message)
          {
            if (Notified != null)
            {
              Notified(this, new NotificationEventArgs(message));
            }
          }
          public void Notify(String format, params object[] args)
          {
            this.Notify(String.Format(format, args));
          }
    
    
    
          #endregion
    
          public TestConnection()
          {
            CompletionTimer = new Timer();
            CompletionTimer.Tick += new EventHandler(CompleteTest);
    
            Command = new OracleCommand(
              "select 'saddr:' || saddr || '-sid:' || sid || '-serial#:' || serial# || '-audsid:' || audsid || '-paddr:' || paddr || '-module:' || module  from gv$session where audsid=Userenv('SESSIONID')");
    
            Command.Connection = new OracleConnection(Configuration.OracleConnectionString);
          }
    
          public String StartTest(Int32 idleTime)
          {
            Command.Connection.Open();
            ConnectionId = (String)Command.ExecuteScalar();
            Notify("Started test with idle time={0}, id={1}.", idleTime, ConnectionId);
            IdleTime = idleTime;
            CompletionTimer.Enabled = true;
            return ConnectionId;
          }
    
          private void CompleteTest(object sender, EventArgs e)
          {
            if (!IsControlConnection)
              CompletionTimer.Enabled = false;
            try
            {
              Command.ExecuteScalar();
              Notify("Test complete on connection with idle time={0}, id={1}.", IdleTime, ConnectionId);
              if (TestCompleted != null)
                TestCompleted(this, EventArgs.Empty);
            }
            catch (OracleException ex)
            {
              if (ex.Number == 12571)
              {
                if (ErrorOccured != null)
                {
                  Notify("Found error on connection with idle time={0}, id={1}.", IdleTime, ConnectionId);
                  ErrorOccured(this, EventArgs.Empty);
                }
              }
              else
              {
                Notify("Unknown error occured on connection with timeout {0}, Error: {1}, \r\n{2}",(IdleTime).ToString(), ex, ConnectionId);
    
              }
            }
            catch (Exception ex)
            {
              Notify("Unknown error occured on connection with timeout {0}, Error: {1}, \r\n{2}", (IdleTime).ToString(), ex, ConnectionId);
            }
            finally
            {
              if(!IsControlConnection)
                Command.Connection.Close();
            }
          }
        }
    
        private void InConnections_TextChanged(object sender, EventArgs e)
        {
          Int32.TryParse(InConnections.Text,out connectionCount);
          Int32.TryParse(InMultiplier.Text,out multiplier);
          Int32.TryParse(InInitialWait.Text, out initialConnectionWait);
    
          OutLongestConnection.Text = (Math.Pow(multiplier,connectionCount-1) * initialConnectionWait).ToString();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
          InConnections_TextChanged(this, EventArgs.Empty);
        }
    
     }
    }
    
