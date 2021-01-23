    public static class Copier
    {
    	public static async Task CopyFiles(Dictionary<string,string> files, Action<int> progressCallback)
    	{
    		for(var x = 0; x < files.Count; x++)
    		{
    			var item = files.ElementAt(x);
    			var from = item.Key;
    			var to = item.Value;
    			
    			using(var outStream = new FileStream(to, FileMode.Create, FileAccess.Write, FileShare.Read))
    			{
    				using(var inStream = new FileStream(from, FileMode.Open, FileAccess.Read, FileShare.Read))
    				{
    					await inStream.CopyToAsync(outStream);
    				}
    			}
    			
    			progressCallback((int)((x+1)/files.Count) * 100);
    		}
    	}
    }
    
    public class MyUI
    {
    	public MyUI()
    	{
    		copyButton.Click += (s,e) => DoCopy();
    	}
    	
    	public async void DoCopy()
    	{
    		await Copier.CopyFiles(new Dictionary<string,string>
    		{
    			{"C:\file1.txt", "C:\users\myuser\desktop\file1.txt"},
    			{"C:\file2.txt", "C:\users\myuser\desktop\file2.txt"}
    		}, prog => MyProgressBar.Value = prog);
    	}
    }
