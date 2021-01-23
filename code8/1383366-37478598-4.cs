    using System;
    using Android.App;
    using Android.OS;
    using Android.Widget;
    
    namespace AndiNative
    {
    	[Activity (Label = "MyLayoutActivity", MainLauncher = true)]			
    	public class MyLayoutActivity: Activity
    	{
    		private static EditText editText;
    		
    		protected override void OnCreate (Bundle bundle)
    		{
    			base.OnCreate (bundle);
    			SetContentView (Resource.Layout.DatePickerTest);
    
    			editText = FindViewById<EditText> (Resource.Id.editText);
    
    			editText.Click += (sender, e) => {
    				DateTime today = DateTime.Today;
    				DatePickerDialog dialog = new DatePickerDialog(this, OnDateSet, today.Year, today.Month - 1, today.Day);
    				dialog.DatePicker.MinDate = today.Millisecond;
    				dialog.Show();
    			};
    		}
    
    		void OnDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
    		{
    			editText.Text = e.Date.ToLongDateString();
    		}
    	}
    }
