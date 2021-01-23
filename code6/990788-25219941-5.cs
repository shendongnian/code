    public partial class Form1
    {
    	private StreamWriter _streamWriter;
    	private StreamReader _streamReader;
    	
    	public Form1()
    	{
    		InitializeComponent();
    	}
    	
    	public void InitializeProcess(object sender, EventArgs args)
    	{
            var processStartInfo = new ProcessStartInfo
            {
               UseShellExecute = false,
               ErrorDialog = false, 
               RedirectStandardError = true,
               RedirectStandardInput = true, 
               RedirectStandardOutput = true                 
            }
            var myProcess = new Process(processStartInfo);
    		Task.Run(() => 
    		{
    			MyProcess.Start();
    			MyProcess.WaitForExit();
    		});
            _streamWriter = MyProcess.StandardInput;
    	    _streamReader = MyProcess.StandardOutput;
        }
    	
    	public void ButtonEventHandler(object sender, EventArgs e)
    	{
    		_streamWriter.Writer( /* write stuff here */ )	
    	}
    }
