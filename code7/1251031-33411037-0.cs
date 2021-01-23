    namespace WinFormsApp
    {
    	public partial class MainForm : Form
    	{
    		public MainForm()
    		{
    			InitializeComponent();
    		}
    
    		async Task<int> LoadDataAsync()
    		{
    			await Task.Delay(2000);
    			return 42;
    		}
    
    		private async void button1_Click(object sender, EventArgs e)
    		{
    			var progressForm = new Form() { 
    				Width = 300, Height = 100, Text = "Please wait... " };
    
    			var progressFormTask = progressForm.ShowDialogAsync();
    	
    			var data = await LoadDataAsync();
    
    			progressForm.Close();
    			await progressFormTask;
    
    			MessageBox.Show(data.ToString());
    		}
    	}
    
    	internal static class DialogExt
    	{
    		public static async Task<DialogResult> ShowDialogAsync(this Form @this)
    		{
    			await Task.Yield();
    			if (@this.IsDisposed)
    				return DialogResult.OK;
    			return @this.ShowDialog();
    		}
    	}
    }
