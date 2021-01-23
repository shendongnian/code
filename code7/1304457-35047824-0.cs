    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace MessageLoop
    {
    	public partial class Form1 : Form
    	{
    		/// <summary>
    		///  WM_WTSSESSION_CHANGE message number for filtering in WndProc
    		/// </summary>
    		private const int WM_WTSSESSION_CHANGE = 0x2b1;
    
    		public Form1()
    		{
    			InitializeComponent();
    			NativeWrapper.WTSRegisterSessionNotification(this, SessionNotificationType.NOTIFY_FOR_ALL_SESSIONS);
    		}
    		protected override void OnClosing(CancelEventArgs e)
    		{
    			NativeWrapper.WTSUnRegisterSessionNotification(this);
    			base.OnClosing(e);
    		}
    		protected override void WndProc(ref Message m)
    		{
    			if (m.Msg == WM_WTSSESSION_CHANGE)
    			{
    				int eventType = m.WParam.ToInt32();
    				int sessionId = m.LParam.ToInt32();
    				WtsSessionChange reason = (WtsSessionChange)eventType;
    				Trace.WriteLine(string.Format("SessionId: {0}, Username: {1}, EventType: {2}", 
    					sessionId, NativeWrapper.GetUsernameBySessionId(sessionId), reason));
    			}
    			base.WndProc(ref m);
    		}
    	}
    }
