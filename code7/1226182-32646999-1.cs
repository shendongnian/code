    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace Samples
    {
    	static class ChatClient
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var name = GetChatName();
    			if (string.IsNullOrEmpty(name)) return;
    			var ipAddress = IPAddress.Parse("127.0.0.1");
    			var client = new TcpClient();
    			try
    			{
    				client.Connect(ipAddress, 8888);
    			}
    			catch (Exception ex)
    			{
    				MessageBox.Show(ex.Message);
    				return;
    			}
    			var netStream = client.GetStream();
    			var send = new BinaryWriter(netStream);
    			send.Write(name);
    			var form = new Form { Text = "Chat - " + name };
    			var tbSend = new TextBox { Dock = DockStyle.Bottom, Parent = form };
    			var tbChat = new TextBox { Dock = DockStyle.Fill, Parent = form, Multiline = true, ReadOnly = true };
    			var messages = new List<string>();
    			tbSend.KeyPress += (_s, _e) =>
    			{
    				if (_e.KeyChar == 13 && !string.IsNullOrWhiteSpace(tbSend.Text))
    				{
    					send.Write(tbSend.Text);
    					tbSend.Text = string.Empty;
    					_e.Handled = true;
    				}
    			};
    			Action<string> onMessageReceived = message =>
    			{
    				if (messages.Count == 100) messages.RemoveAt(0);
    				messages.Add(message);
    				tbChat.Lines = messages.ToArray();
    			};
    			var listener = new Thread(() =>
    			{
    				var listen = new BinaryReader(netStream);
    				while (true)
    				{
    					var message = listen.ReadString();
    					form.BeginInvoke(onMessageReceived, message);
    				}
    			});
    			listener.IsBackground = true;
    			listener.Start();
    			Application.Run(form);
    		}
    		static string GetChatName()
    		{
    			var form = new Form { Text = "Enter name:", StartPosition = FormStartPosition.CenterScreen };
    			var tb = new TextBox { Parent = form, Top = 8, Left = 8, Width = form.ClientSize.Width - 16, Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top };
    			var okButton = new Button { Parent = form, Text = "OK", DialogResult = DialogResult.OK, Left = 8 };
    			var cancelButon = new Button { Parent = form, Text = "Cancel", Left = okButton.Right + 8 };
    			okButton.Top = cancelButon.Top = form.ClientSize.Height - okButton.Height - 8;
    			okButton.Anchor = cancelButon.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
    			form.AcceptButton = okButton;
    			form.CancelButton = cancelButon;
    			var dr = form.ShowDialog();
    			return dr == DialogResult.OK ? tb.Text : null;
    		}
    	}
    }
