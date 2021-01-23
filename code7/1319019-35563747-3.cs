    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace Demo
    {
    	class TestForm : Form
    	{
    		public TestForm()
    		{
    			var panel = new Panel { Dock = DockStyle.Top, BorderStyle = BorderStyle.FixedSingle };
    			openButton = new Button { Text = "Open", Top = 8, Left = 16 };
    			prevButton = new Button { Text = "Prev", Top = 8, Left = 16 + openButton.Right };
    			nextButton = new Button { Text = "Next", Top = 8, Left = 16 + prevButton.Right };
    			panel.Height = 16 + openButton.Height;
    			panel.Controls.AddRange(new Control[] { openButton, prevButton, nextButton });
    			pageViewer = new PictureBox { Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom };
    			ClientSize = new Size(850, 1100 + panel.Height);
    			Controls.AddRange(new Control[] { panel, pageViewer });
    			openButton.Click += OnOpenButtonClick;
    			prevButton.Click += OnPrevButtonClick;
    			nextButton.Click += OnNextButtonClick;
    			Disposed += OnFormDisposed;
    			UpdatePageInfo();
    		}
    
    		private Button openButton;
    		private Button prevButton;
    		private Button nextButton;
    		private PictureBox pageViewer;
    		private PageBuffer pageData;
    		private int currentPage;
    
    		private void OnOpenButtonClick(object sender, EventArgs e)
    		{
    			using (var dialog = new OpenFileDialog())
    			{
    				if (dialog.ShowDialog(this) == DialogResult.OK)
    					Open(dialog.FileName);
    			}
    		}
    
    		private void OnPrevButtonClick(object sender, EventArgs e)
    		{
    			SelectPage(currentPage - 1);
    		}
    
    		private void OnNextButtonClick(object sender, EventArgs e)
    		{
    			SelectPage(currentPage + 1);
    		}
    
    		private void OnFormDisposed(object sender, EventArgs e)
    		{
    			if (pageData != null)
    				pageData.Dispose();
    		}
    
    		private void Open(string path)
    		{
    			var data = PageBuffer.Open(path);
    			pageViewer.Image = null;
    			if (pageData != null)
    				pageData.Dispose();
    			pageData = data;
    			SelectPage(0);
    		}
    
    		private void SelectPage(int index)
    		{
    			pageViewer.Image = pageData.GetPage(index);
    			currentPage = index;
    			UpdatePageInfo();
    		}
    
    		private void UpdatePageInfo()
    		{
    			prevButton.Enabled = pageData != null && currentPage > 0;
    			nextButton.Enabled = pageData != null && currentPage < pageData.PageCount - 1;
    		}
    	}
    
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
    
    	class PageBuffer : IDisposable
    	{
    		public static PageBuffer Open(string path)
    		{
    			return new PageBuffer(File.OpenRead(path));
    		}
    
    		private PageBuffer(Stream stream)
    		{
    			this.stream = stream;
    			Source = Image.FromStream(stream);
    			PageCount = Source.GetFrameCount(FrameDimension.Page);
    			if (PageCount < 2) return;
    			pages = new Image[PageCount];
    			var worker = new Thread(LoadPages) { IsBackground = true };
    			worker.Start();
    		}
    
    		private void LoadPages()
    		{
    			for (int index = 0; ; index++)
    			{
    				lock (syncLock)
    				{
    					if (disposed) return;
    					if (index >= pages.Length)
    					{
    						// If you don't need the source image, 
    						// uncomment the following line to free some resources
    						//DisposeSource();
    						return;
    					}
    					if (pages[index] == null)
    						pages[index] = LoadPage(index);
    				}
    			}
    		}
    
    		private Image LoadPage(int index)
    		{
    			Source.SelectActiveFrame(FrameDimension.Page, index);
    			return new Bitmap(Source);
    		}
    
    		private Stream stream;
    		private Image[] pages;
    		private object syncLock = new object();
    		private bool disposed;
    
    		public Image Source { get; private set; }
    		public int PageCount { get; private set; }
    		public Image GetPage(int index)
    		{
    			if (disposed) throw new ObjectDisposedException(GetType().Name);
    			if (PageCount < 2) return Source;
    			var image = pages[index];
    			if (image == null)
    			{
    				lock (syncLock)
    				{
    					image = pages[index];
    					if (image == null)
    						image = pages[index] = LoadPage(index);
    				}
    			}
    			return image;
    		}
    
    		public void Dispose()
    		{
    			if (disposed) return;
    			lock (syncLock)
    			{
    				disposed = true;
    				if (pages != null)
    				{
    					foreach (var item in pages)
    						if (item != null) item.Dispose();
    					pages = null;
    				}
    				DisposeSource();
    			}
    		}
    
    		private void DisposeSource()
    		{
    			if (Source != null)
    			{
    				Source.Dispose();
    				Source = null;
    			}
    			if (stream != null)
    			{
    				stream.Dispose();
    				stream = null;
    			}
    		}
    	}
    }
