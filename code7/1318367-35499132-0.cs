    public static void DisableSoftKeyboard (EditText editText)
    {
    	((InputMethodManager)GetSystemService(Context.InputMethodService)).HideSoftInputFromWindow(editText.WindowToken, 0);
    	if (Build.VERSION.SdkInt >= BuildVersionCodes.Honeycomb) {
    		editText.SetRawInputType (InputTypes.ClassText);
    		editText.SetTextIsSelectable (true);
    	} else {
    		editText.SetRawInputType (InputTypes.Null);
    		editText.Focusable = true;
    	}
    }
