    void Main()
    {
    	string url = "http://img1.ak.crunchyroll.com/i/croll_manga/e/257692e8c297b8907e2607964454b941_1438752352_main";
    	Console.WriteLine(open(url));
    }
    
    
     public static async Task<string> open(string url)
    	{
    
    		using (HttpClient page = new HttpClient())
    		{
    			try
    			{
    				//page.Encoding = Encoding.UTF8;
    				//page.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:40.0) Gecko/20100101 Firefox/40.0";
    				page.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:40.0) Gecko/20100101 Firefox/40.0");
    				return await page.GetStringAsync(url);
    			}
    
    			catch (Exception er)
    			{
    				//MessageBox.Show(er.ToString());
    				return null;
    			}
    		}
    
    	}
    	
