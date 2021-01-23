    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Threading;
    
    namespace WpfApplication
    {
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			InitializeComponent();
    			this.Loaded += MainWindow_Loaded;
    		}
    
    		// testing ShowDialogAsync
    		async void MainWindow_Loaded(object sender, RoutedEventArgs e)
    		{
    			var modal1 = new Window { Title = "Modal 1" };
    			modal1.Loaded += async delegate
    			{
    				await Task.Delay(1000);
    
    				var modal2 = new Window { Title = "Modal 2" };
    				try
    				{
    					await modal2.ShowDialogAsync();
    				}
    				catch (OperationCanceledException)
    				{
    					Debug.WriteLine("Cancelled: " + modal2.Title);
    				}
    			};
    
    			await Task.Delay(1000);
    			// close modal1 in 5s
    			// this would automatically close modal2
    			var cts = new CancellationTokenSource(5000); 
    			try
    			{
    				await modal1.ShowDialogAsync(cts.Token);
    			}
    			catch (OperationCanceledException)
    			{
    				Debug.WriteLine("Cancelled: " + modal1.Title);
    			}
    		}
    	}
    
    	/// <summary>
    	/// WindowExt
    	/// </summary>
    	public static class WindowExt
    	{
    		[ThreadStatic]
    		static CancellationToken s_currentToken = default(CancellationToken);
    
    		public static async Task<bool?> ShowDialogAsync(
    			this Window @this, 
    			CancellationToken token = default(CancellationToken))
    		{
    			token.ThrowIfCancellationRequested();
    			var previousToken = s_currentToken;
    			using (var cts = CancellationTokenSource.CreateLinkedTokenSource(previousToken, token))
    			{
    				var currentToken = s_currentToken = cts.Token;
    				try
    				{
    					return await @this.Dispatcher.InvokeAsync(() =>
    					{
    						using (currentToken.Register(() => 
    							@this.Close(), 
    							useSynchronizationContext: true))
    						{
    							try
    							{
    								var result = @this.ShowDialog();
    								currentToken.ThrowIfCancellationRequested();
    								return result;
    							}
    							finally
    							{
    								@this.Close();
    							}
    						}
    					}, DispatcherPriority.Normal, currentToken);
    				}
    				finally
    				{
    					s_currentToken = previousToken;
    				}
    			}
    		}
    	}
    }
