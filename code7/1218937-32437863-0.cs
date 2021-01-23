    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Newtonsoft.Json;
    
    
    public class Program
    {
    	public static void Main(string[] args)
    	{
    
    		var webClient = new WebClient();
    		var json = webClient.DownloadString("https://gist.githubusercontent.com/maskaravivek/33aa0d6556bbb9ecb77a/raw/b815daa55719a754eef5117321e2c0c5621c6a18/gistfile1.txt");
    		var notifications = JsonConvert.DeserializeObject<Notification[]>(json);
    
    		Console.WriteLine(notifications.Count());
    		Console.ReadLine();
    	}
    }
    
    //adjust the data types according to your needs
    public class Notification
    {
    	public string notificationId { get; set; }
    	public string readFlag { get; set; }
    	public string importantFlag { get; set; }
    	public string subject { get; set; }
    	public string folder { get; set; }
    	public string creationTime { get; set; }
    	public string notificationCount { get; set; }
    	public string jobId { get; set; }
    	public Dictionary<string, string> recruitersMap { get; set; }
    	public Dictionary<string, string> jobsMap { get; set; }
    }
