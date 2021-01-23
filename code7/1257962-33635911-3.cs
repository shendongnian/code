    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    namespace Demo
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var responses = new string[] { @"{""reason"":""unlucky"",""message"":null,""code"":460}",
    			@"{""errorState"":null,""credits"":6310,""itemInfo"":[{""tradeId"":717011415,""itemData"":{""id"":101619602325
    			,""timestamp"":1447170628,""formation"":""f3412"",""untradeable"":false,""assetId"":158023,""rating"":94,""itemType""
    			:""player"",""resourceId"":-2147325625,""owners"":1,""discardValue"":752,""itemState"":""forSale"",""cardsubtypeid""
    			:3,""lastSalePrice"":0,""morale"":50,""fitness"":99,""injuryType"":""none"",""injuryGames"":0,""preferredPosition""
    			:""RW"",""statsList"":[{""value"":0,""index"":0},{""value"":0,""index"":1},{""value"":0,""index"":2},{""value"":0,""index""
    			:3},{""value"":0,""index"":4}],""lifetimeStats"":[{""value"":0,""index"":0},{""value"":0,""index"":1},{""value"":0,""index""
    			:2},{""value"":0,""index"":3},{""value"":0,""index"":4}],""training"":0,""contract"":7,""suspension"":0,""attributeList""
    			:[{""value"":92,""index"":0},{""value"":88,""index"":1},{""value"":86,""index"":2},{""value"":95,""index"":3},{""value""
    			:24,""index"":4},{""value"":62,""index"":5}],""teamid"":241,""rareflag"":1,""playStyle"":250,""leagueId"":53,""assists""
    			:0,""lifetimeAssists"":0,""loyaltyBonus"":1,""pile"":5,""nation"":52},""tradeState"":""active"",""buyNowPrice"":1726000
    			,""currentBid"":0,""offers"":0,""watched"":null,""bidState"":""none"",""startingBid"":426000,""confidenceValue"":100
    			,""expires"":3212,""sellerName"":""FIFA UT"",""sellerEstablished"":0,""sellerId"":0,""tradeOwner"":false}],""duplicateItemIdList""
    			:null,""bidTokens"":{},""currencies"":[{""name"":""COINS"",""funds"":6310,""finalFunds"":6310},{""name"":""POINTS""
    			,""funds"":0,""finalFunds"":0},{""name"":""DRAFT_TOKEN"",""funds"":0,""finalFunds"":0}]}" };
    
    			foreach (var response in responses)
    			{
    				var instance = JsonConvert.DeserializeObject<RootObject>(response);
    				if (instance.code != 0)
    				{
    					//Do things for error
    				}
    				else
    				{	
    					//Do things for success
    				}
    			}
    		}
    	}
    
    	public class StatsList
    	{
    		public int value { get; set; }
    		public int index { get; set; }
    	}
    
    	public class LifetimeStat
    	{
    		public int value { get; set; }
    		public int index { get; set; }
    	}
    
    	public class AttributeList
    	{
    		public int value { get; set; }
    		public int index { get; set; }
    	}
    
    	public class ItemData
    	{
    		public long id { get; set; }
    		public int timestamp { get; set; }
    		public string formation { get; set; }
    		public bool untradeable { get; set; }
    		public int assetId { get; set; }
    		public int rating { get; set; }
    		public string itemType { get; set; }
    		public int resourceId { get; set; }
    		public int owners { get; set; }
    		public int discardValue { get; set; }
    		public string itemState { get; set; }
    		public int cardsubtypeid { get; set; }
    		public int lastSalePrice { get; set; }
    		public int morale { get; set; }
    		public int fitness { get; set; }
    		public string injuryType { get; set; }
    		public int injuryGames { get; set; }
    		public string preferredPosition { get; set; }
    		public List<StatsList> statsList { get; set; }
    		public List<LifetimeStat> lifetimeStats { get; set; }
    		public int training { get; set; }
    		public int contract { get; set; }
    		public int suspension { get; set; }
    		public List<AttributeList> attributeList { get; set; }
    		public int teamid { get; set; }
    		public int rareflag { get; set; }
    		public int playStyle { get; set; }
    		public int leagueId { get; set; }
    		public int assists { get; set; }
    		public int lifetimeAssists { get; set; }
    		public int loyaltyBonus { get; set; }
    		public int pile { get; set; }
    		public int nation { get; set; }
    	}
    
    	public class ItemInfo
    	{
    		public int tradeId { get; set; }
    		public ItemData itemData { get; set; }
    		public string tradeState { get; set; }
    		public int buyNowPrice { get; set; }
    		public int currentBid { get; set; }
    		public int offers { get; set; }
    		public object watched { get; set; }
    		public string bidState { get; set; }
    		public int startingBid { get; set; }
    		public int confidenceValue { get; set; }
    		public int expires { get; set; }
    		public string sellerName { get; set; }
    		public int sellerEstablished { get; set; }
    		public int sellerId { get; set; }
    		public bool tradeOwner { get; set; }
    	}
    
    	public class BidTokens
    	{
    	}
    
    	public class Currency
    	{
    		public string name { get; set; }
    		public int funds { get; set; }
    		public int finalFunds { get; set; }
    	}
    
    	public class RootObject
    	{
    		public string reason { get; set; }
    		public object message { get; set; }
    		public int code { get; set; }
    
    
    		public object errorState { get; set; }
    		public int credits { get; set; }
    		public List<ItemInfo> itemInfo { get; set; }
    		public object duplicateItemIdList { get; set; }
    		public BidTokens bidTokens { get; set; }
    		public List<Currency> currencies { get; set; }
    
    		public override string ToString()
    		{
    			return $"Contains Error: {code != 0}";
    		}
    	}
    }
