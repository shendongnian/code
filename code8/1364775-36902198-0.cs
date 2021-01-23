    public partial class Form1 : Form
    {
    	DataClass dc;
    	public Form1()
    	{
    		InitializeComponent();
    		dc = new DataClass();
    		label1.DataBindings.Add("Text", dc, "X", true, DataSourceUpdateMode.OnPropertyChanged);
    	}
    	
    	private void button1_Click(object sender, EventArgs e)
    	{
    		dc.X++;
    	}
    }
    
    public class DataClass : INotifyPropertyChanged
    {
    	int x = 50;
    	public int X
    	{
    		get { return x; }
    		set
    		{
    			x = value;
    			NotifyPropertyChanged("X");
    		}
    	}
    	public event PropertyChangedEventHandler PropertyChanged;
    	private void NotifyPropertyChanged(String info)
    	{
    		var handler = PropertyChanged;
    		if (handler != null)
    		{
    			handler(this, new PropertyChangedEventArgs(info));
    		}
    	}
    }
