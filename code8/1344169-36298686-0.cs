      using System;
    using Xamarin.Forms.Platform.Android;
    using Xamarin.Forms;
    using communityhealth;
    using Android.Graphics;
    using communityhealth.Android;
    
    
    [assembly: ExportRenderer (typeof (MyUsernameEntry), typeof (MyUsernameEntryRenderer))]
    [assembly: ExportRenderer (typeof (MyPasswordEntry), typeof (MyPasswordEntryRenderer))]
    [assembly: ExportRenderer (typeof (MyEntry), typeof (MyEntryRenderer))]
    
    namespace communityhealth.Android
    {
    	public class MyEntryRenderer : EntryRenderer
    	{
    		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
    		{
    			base.OnElementChanged (e);
    			if (e.OldElement == null) {   // perform initial setup
    				// lets get a reference to the native control
    				var nativeEditText = (global::Android.Widget.EditText) Control;
    				// do whatever you want to the textField here!
    				nativeEditText.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
    				nativeEditText.SetTextColor(global::Android.Graphics.Color.White);
    				Typeface font = Typeface.CreateFromAsset (Forms.Context.Assets, "Neris-Light.otf");
    				nativeEditText.TextSize = 14f;
    				nativeEditText.Typeface = font;
    			}
    		}
    	}
    
    	public class MyUsernameEntryRenderer : MyEntryRenderer
    	{
    		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
    		{
    			base.OnElementChanged (e);
    
    			if (e.OldElement == null) {
    				// lets get a reference to the native control
    				var nativeEditText = (global::Android.Widget.EditText) Control;
    				nativeEditText.Hint = "Username";
    				nativeEditText.SetHintTextColor (global::Android.Graphics.Color.White);
    				nativeEditText.TextSize = 18f;
    			}
    		}
    	}
    
    	public class MyPasswordEntryRenderer : MyEntryRenderer
    	{
    		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
    		{
    			base.OnElementChanged (e);
    
    			if (e.OldElement == null) {
    				// lets get a reference to the native control
    				var nativeEditText = (global::Android.Widget.EditText) Control;
    				nativeEditText.Hint = "Password";
    				nativeEditText.SetHintTextColor (global::Android.Graphics.Color.White);
    				nativeEditText.TextSize = 18f;
    			}
    		}
    	}
    }
