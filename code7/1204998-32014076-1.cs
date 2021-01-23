    using System;
    using System.Text.RegularExpressions;
    using CsQuery;
    public static class Scraper
    { 
        public static string RemoveHTMLTags(string html)
        {
    		return Regex.Replace(html, "<.*?>", string.Empty);
        }
    	
    	public static bool FindWinner(string item)
    	{
    		if(item.Contains("(win)"))
    		{
    			return true;
    		}
    		
    		return false;
    	}
    }
    
    public class Program
    {
        public static void Main()
        {
    		CQ dom = CQ.CreateFromUrl("http://csgolounge.com/match?m=4961");
    		CQ bold = dom["div > a b"];		
    		CQ italic = dom["div > a i"];
    		
    		string team1 = Scraper.RemoveHTMLTags(bold[0].Render());
    		string team2 = Scraper.RemoveHTMLTags(bold[1].Render());
    		string team1Percent = Scraper.RemoveHTMLTags(italic[0].Render());
    		string team2Percent = Scraper.RemoveHTMLTags(italic[1].Render());			
    			
    		if(Scraper.FindWinner(team1))
    		{
    			Console.WriteLine("-- Winner --");
    			Console.WriteLine(team1 + " - " + team1Percent);
    			Console.WriteLine("-- Loser --");
    			Console.WriteLine(team2 + " - " + team2Percent);			
    		}
    		else
    		{								
    			Console.WriteLine("-- Winner --");
    			Console.WriteLine(team2 + " - " + team1Percent);
    			Console.WriteLine("-- Loser --");
    			Console.WriteLine(team1 + " - " + team2Percent);
    		}		
    	}	
    }
