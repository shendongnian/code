    System.Collections.Generic;
    using Xamarin.Forms;
    using Xamarin.Forms.Maps;
    using System;
    
    namespace App
    {
    	public class MapPage : ContentPage
    	{
    		public  CustomMap customMap1{ get; set;}
    		public MapPage ()
    		{
    			Title ="Stores";
    			Icon = "flag_map_marker4.png";
    
    			
    			 var customMap = new CustomMap {
    				MapType = MapType.Street,
    				WidthRequest = App.ScreenWidth,
    				HeightRequest = App.ScreenHeight
    			};
    					
    			customMap.CustomPins = new List<CustomPin>();
    			if (App.Items != null && App.Items.Count > 0) {
    				foreach (var t in App.Items) {
    					var temp = new CustomPin () {
    						Pin = new Pin () {
    							Label = t.Name,
    							Type = PinType.Place,
    							Position = new Position (t.Lat, t.Lon),
    							Address = t.Address1
    						},
    						Url = t.Link
    					};
    					customMap.CustomPins.Add (temp);
    				}
    				foreach (var pin in customMap.CustomPins) {
    					customMap.Pins.Add (pin.Pin);
    				}
    				// dont delete below code ,they will save you if timer doesnt work .
    
    				//var temp1 = new MapSpan(customMap.CustomPins [0].Pin.Position,
    //				if(Device.OS == TargetPlatform.iOS)
    //				customMap.MoveToRegion (MapSpan.FromCenterAndRadius (customMap.CustomPins [0].Pin.Position, Distance.FromMiles (0.20)));
    
    				if(Device.OS == TargetPlatform.Android)
    				customMap.MoveToRegion (MapSpan.FromCenterAndRadius (customMap.CustomPins [0].Pin.Position, Distance.FromMiles (55.0)));
    				if (Device.OS == TargetPlatform.iOS) {
    					Device.StartTimer (TimeSpan.FromMilliseconds (500), () => {
    						customMap.MoveToRegion (MapSpan.FromCenterAndRadius (customMap.CustomPins [0].Pin.Position, Distance.FromMiles (55.0)));
    						return false;
    					});
    				}
    			}
    
    			Content = customMap;
    		}
    
    	}
    
    
    }
