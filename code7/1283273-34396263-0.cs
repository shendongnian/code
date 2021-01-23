    /// <summary>
    /// Deletes all cookies stored in the CookieManager on Android.
    /// </summary>
    public void DeleteAllCookies() {
        if(_cookieManager.HasCookies) {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop) {
			    _cookieManager.RemoveAllCookies(null);
			} else { _cookieManager.RemoveAllCookie(); }
        }
    }
