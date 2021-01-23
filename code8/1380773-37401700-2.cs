    public partial class frmGifPlayer : Form
    {
    	List<Image> images = new List<Image>();
    	int imageIdx = 0;
    	bool playing = false;
    	public frmGifPlayer()
    	{
    		InitializeComponent();
    	}
    
    	private void btnLoadGIF_Click(object sender, EventArgs e)
    	{
    		OpenFileDialog file = new OpenFileDialog();
    		if (file.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
    		{
    			return;
    		}
    		Image img = Image.FromFile(file.FileName);
    
    		lock (images)
    		{
                // Load your images into a List<Image> collection...
    			images.Clear();
    			for (int i = 0; i < img.GetFrameCount(System.Drawing.Imaging.FrameDimension.Time); i++)
    			{
    				img.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Time, i);
    				images.Add(new Bitmap(img));
    			}
    		}
    
    		
    	}
    
    	private void PlayImages(List<Image> images)
    	{
            // Cycle through the images in a thread...
    		ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
    			{
    				List<Image> img = (List<Image>)o;
    				int curIdx = 0;
    				do
    				{
    					lock (images)
    					{
                            // Update your variables then callback to the form to change the image.
    						imageIdx = curIdx;
    						pbGif.Image = img[imageIdx];
    						Invoke(new Action(() =>
    						{
    							txtCurFrame.Text = imageIdx.ToString();
    						}));
    						curIdx++;
    						if (curIdx >= img.Count)
    							curIdx = 0;
    					}
    					Thread.Sleep(TimeSpan.FromSeconds(.5));
    				} while (playing);
    			}), images);
    	}
    
    
    	private void btnStartStop_Click(object sender, EventArgs e)
    	{
    		lock (images)
    		{
    			playing = !playing;
    		}
    		if (playing)
    		{
    			btnStartStop.Text = "Stop";
    			PlayImages(images);
    		}
    		else
    			btnStartStop.Text = "Start";
    	}
    }
