    using System;
    using Xamarin.Forms;
    using XLabs.Forms.Controls;
    
    namespace Facedetection
    {
    	public class firstPage : ContentPage
    	{
    		string statename;
    
    		public firstPage ()
    		{
     
    			CheckBox checkbox = new CheckBox () {
    				TextColor=Color.Blue,
    				CheckedText="I am checked"
     
    			};
    
    			Picker statepick = new Picker ();
    			statepick.WidthRequest = 300;
    			statepick.Title = "Select a state";
    			statepick.Items.Add ("India");
    			statepick.Items.Add ("US");
    			statepick.Items.Add ("Arizona");
    			statepick.Items.Add ("China");
    
    			statepick.SelectedIndexChanged += (sender, e) => {
    				if (statepick.SelectedIndex == -1) {
    					DisplayAlert ("Title", "Item not selected", "ok");
    				} else {
    					statename = statepick.Items [statepick.SelectedIndex];
    					Console.WriteLine ("Selected country is:" + statename);
    				}
    			};
    
    
    
    
    			Content = new StackLayout { 
    				Children = {
    					checkbox,statepick
    				}
    			};
    		}
    	}
    }
    
    
    
    
    worked for me 
    
     
