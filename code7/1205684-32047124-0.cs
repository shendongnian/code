    using System;
    using System.Drawing;
    using System.Threading;
    using System.Threading.Tasks;
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
    
    		class TestForm : Form
    		{
    			public TestForm()
    			{
    				var label = new Label { Parent = this, AutoSize = true, Top = 8, Left = 8 };
    				animateHelper = new AnimateHelper(label);
    				int left = 8;
    				foreach (var action in (ButtonAction[])Enum.GetValues(typeof(ButtonAction)))
    				{
    					var button = new Button { Parent = this, AutoSize = true, Text = action.ToString(), Left = left };
    					button.Top = DisplayRectangle.Bottom - button.Height - 8;
    					button.Click += (sender, e) => Execute(action);
    					left += button.Width + 8;
    				}
    			}
    			protected override void Dispose(bool disposing)
    			{
    				if (disposing && animateHelper != null) animateHelper.Cancel(); 
    				base.Dispose(disposing);
    			}
    			enum ButtonAction { TypewriteText, RepeatText, Cancel }
    			private void Execute(ButtonAction action)
    			{
    				// the original question
    				switch (action)
    				{
    					case ButtonAction.TypewriteText:
    						TypewriteText("This is a typewriter text animantion test.");
    						break;
    					case ButtonAction.RepeatText:
    						RepeatText("This is a repeating text animantion test.");
    						break;
    					case ButtonAction.Cancel:
    						animateHelper.Cancel();
    						break;
                    }
    			}
    			AnimateHelper animateHelper;
    			void TypewriteText(string text)
    			{
    				animateHelper.Execute(async (output, ct) =>
    				{
    					bool clear = true;
    					try
    					{
    						if (string.IsNullOrEmpty(text)) return;
    						output.ForeColor = Color.Blue;
    						for (int length = 1; ; length++)
    						{
    							if (ct.IsCancellationRequested) return;
    							output.Text = text.Substring(0, length);
    							if (length == text.Length) break;
    							await Task.Delay(50, ct);
    						}
    						clear = false;
    					}
    					finally { if (clear) output.Text = string.Empty; }
    				});
    			}
    			void RepeatText(string text)
    			{
    				animateHelper.Execute(async (output, ct) =>
    				{
    					try
    					{
    						if (string.IsNullOrEmpty(text)) return;
    						output.ForeColor = Color.Red;
    						while (true)
    						{
    							for (int length = 1; length <= text.Length; length++)
    							{
    								if (ct.IsCancellationRequested) return;
    								output.Text = text.Substring(text.Length - length);
    								await Task.Delay(50, ct);
    							}
    							for (int pad = 1; pad < text.Length; pad++)
    							{
    								if (ct.IsCancellationRequested) return;
    								output.Text = new string(' ', pad) + text.Substring(0, text.Length - pad);
    								await Task.Delay(50, ct);
    							}
    							if (ct.IsCancellationRequested) return;
    							output.Text = string.Empty;
    							await Task.Delay(250, ct);
    						}
    					}
    					finally { output.Text = string.Empty; }
    				});
    			}
    		}
    
    		class AnimateHelper
    		{
    			Label output;
    			Task task;
    			CancellationTokenSource cts;
    			public AnimateHelper(Label output) { this.output = output; }
    			void Reset()
    			{
    				if (cts != null) { cts.Dispose(); cts = null; }
    				task = null;
    			}
    			public void Cancel() { DontCare(CancelAsync()); }
    			async Task CancelAsync()
    			{
    				if (task != null && !task.IsCompleted)
    				{
    					try { cts.Cancel(); } catch { }
    					try { await task; } catch { }
    				}
    				Reset();
    			}
    			public void Execute(Func<Label, CancellationToken, Task> action) { DontCare(ExecuteAsync(action)); }
    			async Task ExecuteAsync(Func<Label, CancellationToken, Task> action)
    			{
    				await CancelAsync();
    				cts = new CancellationTokenSource();
    				task = action(output, cts.Token);
    				try { await task; } catch { }
    				Reset();
    			}
    			// make compiler happy
    			static void DontCare(Task t) { }
    		}
    	}
    }
