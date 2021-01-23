	# CSharpToast
	Create a toast in c#
	This is a Microsoft Visual Studio project that demonstrates showing a toast message to the user.
	A toast message is one that appears, then after a delay, disappears without user intervention.
	This is needed when either the default language implementation is lacking, see java Android, or when there is no default language implementation.
	The steps below illustrate the steps I took to create the toast, 
	but you can, if desired, just download the app here with all of these steps already completed.
	Usage:
	  Call: Toast.show ("This is a test toast.");
	 
	DownloadURL:
	  git clone https://github.com/pstorli/CSharpToast
	  
	Steps To Create:
	  1) Create a new application in MS Visual Studio. 
	  1.1) File -> New -> Application -> Windows Forms App (.NET Framework)
	  1.2) Name app as desired, here I used CSharpToast
	  
	  2) Adjust initial form/screen
	  2.1) Set Form1.cs name to MainWindow.cs
	  2.4) Set the StartPosition to CenterScreen
	  2.5) Add a button1 to the form. Set text to "Make Toast"
	  2.6) Double click button. A new method should appear:
		   private void button1_Click(object sender, EventArgs e)
	  2.7) Add this code to it: 
		   Toast.show ("Toast is done!");
	  
	  3) Create the toast form.
	  3.1) In the solution explorer, Add -> New Item -> Windows Form
	  3.1.1) Set the name to Toast.cs
	  3.1.2) Set the toast form width and height to toast size, say 6 inches wide by 1/2" tall.
	  3.1.3) Set the FormBorderStyle to None
	  3.1.4) Set the background color to white.
	  3.1.5) Set the start position to CenterScreen
	  
	  3.2) Add a label to your form
	  3.2.1) Set the name to Message
	  3.2.2) Set autosize to false.
	  3.2.3) Set textalign to MiddleCenter.
	  3.2.4) Set the background color to white.
	  3.2.5) Set Dock to fill.
		
	  3.3) Add some processing logic to file Toast.cs
	  
	  3.3.1) Change Toast.cs from this:
	  
		using System.Windows.Forms;
		namespace CSharpToast
		{    
			public partial class Toast : Form { 
				public Toast()
				{
					InitializeComponent();
				}
			}
		}
		
	 3.3.2) to this:
	 
	 3.3.3) Added DEFAULT_MS_DELAY to control how long, by default toast shoould show up.
	 3.3.4) Added delegate void SafeOnTimedEvent to call Close from differenet thread.
	 3.3.5) Added constructor with just message and one with message and delay, to override DEFAULT_MS_DELAY
	 3.3.6) Created toast and added a timer to call, void OnTimedEvent() , when toast is done 
			which calls Toast.close(); on correct thread.
			
		using System;
		using System.Timers;
		using System.Windows.Forms;
		namespace CSharpToast
		{    
			public partial class Toast : Form {
				public static int DEFAULT_MS_DELAY = 2500;
				private delegate void SafeOnTimedEvent(Object source, ElapsedEventArgs e);
				public Toast (String message)
				{
					InitializeComponent();
					Message.Text = message;
				}
				public static Toast show (String message)
				{
					return show(message, DEFAULT_MS_DELAY);
				}
				public static Toast show (String message, int ms)
				{
					Toast toast = new Toast(message);
					System.Timers.Timer aTimer = new System.Timers.Timer(ms);
					aTimer.Elapsed += toast.OnTimedEvent;
					aTimer.AutoReset = false;
					aTimer.Enabled = true;
					toast.ShowDialog();
					return toast;
				}
				private void OnTimedEvent (Object source, ElapsedEventArgs e)
				{
					if (this.InvokeRequired)
					{
						var d = new SafeOnTimedEvent(OnTimedEvent);
						Invoke(d, new object[] { source, e });
					}
					else
					{
						Close();
					}
				}        
			}
		}
		
		3.4) Run app
		3.4.1) The main screen with the "Make Toast" button should appear.
		3.4.2) When you press the "Make Toast" button, 
		3.4.3) a white toast popup should appear that says "Toast is Done!"
		3.4.4) which should disappear in 2500 ms.
		
		"I've looked at toast from both sides now, the win and lose and still somehow
		it's toast's illusions I recall, I really don't like toast in c# at all."
		~Except my CSharpToast version.
