	foreach (string value in array)
	{
         // each time we are here, we are going to overwrite the row.Visibility, 
         // so only the value that was set in the last iteration stays.
		 if (t.IndexOf(value, StringComparison.CurrentCulture) == -1)
		 {  
			 row.Visibility = Visibility.Collapsed;
		 }
         // also > 0 restricts the substring to be found in the beginning of the string
         // you've probably meant >= 0 or != -1
		 else if (t.IndexOf(value, StringComparison.CurrentCulture) > 0)
		 {
			 row.Visibility = Visibility.Visible;
		 }
	}
