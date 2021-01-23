    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    
    namespace Tests
    {
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			Application.Run(new TestForm());
    		}
    	}
    	class TestForm : Form, INotifyPropertyChanged
    	{
    		public TestForm()
    		{
    			var label = new Label { Parent = this, Left = 16, Top = 16, AutoSize = false, BorderStyle = BorderStyle.FixedSingle };
    			label.DataBindings.Add("Text", this, "NoteIndex");
    			var timer = new Timer { Interval = 200, Enabled = true };
    			timer.Tick += (sender, e) => NoteIndex = (NoteIndex + 1) % 10;
    		}
    		int note_index;
    		public int NoteIndex
    		{
    			get { return note_index; }
    			private set
    			{
    				if (note_index != value)
    				{
    					note_index = value;
    					NotifyPropertyChanged();
    				}
    			}
    		}
    		public event PropertyChangedEventHandler PropertyChanged;
    		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    		{
    			if (PropertyChanged != null)
    			{
    				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    			}
    		}
    	}
    }
