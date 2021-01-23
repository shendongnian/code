    public class GSWatchModel : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
    	private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    	{
    		if (PropertyChanged != null)
    		{
    			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    
    	private ObservableCollection<uint> aDCSamples = new ObservableCollection<uint>();
    	public ObservableCollection<uint> ADCSamples
    	{
    		get
    		{
    			return aDCSamples;
    		}
    
    		set
    		{
    			aDCSamples = value;
    			NotifyPropertyChanged("ADCSamples");
    		}
    	}
    
    	public GSWatchModel()
    	{
    		CommLink = new GSCommManager();
    
    		for (int i = 0; i < 128; i++)
    		{
    			ADCSamples.Add((uint)(i));      //initial values for demo
    		}
    	}
    
    	uint muki = 0;
    	public void StartStreamADC()
    	{
    		GSPacket StreamRequestPacket = new GSPacket(GSPTypes.Stream);
    		CommLink.SendViaGSWatchLink(StreamRequestPacket);
    
    		for (int i = 0; i < 128; i++)
    		{
    			ADCSamples[i] = (uint)i / 10;   //steps for demonstration
    		}
    
    		muki += 100;
    	}
    }
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StreamChart.Series[0].Points.DataBindY(GSWatch.ADCSamples);
        }
    
        private GSWatchModel GSWatch = new GSWatchModel();
    
        private void button2_Click(object sender, EventArgs e)
        {
            GSWatch.StartStreamADC();
        }
    }
