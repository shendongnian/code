    public partial class MainWindow : Window
    {
    	public MainWindow()
    	{
    		InitializeComponent();
    	}
    
    	Task<string> calculation;
    	string Result;
    	string Text;
    
    	private async void button_Click(object sender, RoutedEventArgs e)
    	{
    		await Invoke(() => Foo());
    		if (!string.IsNullOrEmpty(Result)) Text += $"   --->   {Result}";
    	}
    
    	private async Task Invoke(Func<string> function)
    	{
    		if (calculation?.Status == TaskStatus.Running) await calculation;
    		calculation = Task.Run(function);
    		InvokeA(() => prg.Height = double.NaN);
    		InvokeA(() => prg.Visibility = Visibility.Visible);
    		Result = await calculation;
    		InvokeA(() => prg.Visibility = Visibility.Hidden);
    		InvokeA(() => prg.Height = 0);
    	}
    
    	private void InvokeA(Action a) { a(); }
    
    	static string Foo()
    	{
    		Thread.Sleep(5000);
    		return "Bar";
    	}
    }
