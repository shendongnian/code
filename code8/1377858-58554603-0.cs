    private void SendMail(string subject, string body)
    {
        using (var intentClass = new AndroidJavaClass("android.content.Intent"))
        {
            // intent = new Intent(Intent.ACTION_SEND);
            using (var intentObject = new AndroidJavaObject("android.content.Intent", intentClass.GetStatic<string>("ACTION_SENDTO")))
            {
                //intent.setData(Uri.parse("mailto:"));
                var uriClass = new AndroidJavaClass("android.net.Uri");
                var uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "mailto:");
                intentObject.Call<AndroidJavaObject>("setData", uriObject);
                // intent.putExtra(Intent.EXTRA_SUBJECT, emailSubject);
                intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
                //intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_EMAIL"), "youremail@abc.xyz");
                string[] email = { "youremail@abc.xyz" };
                intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_EMAIL"), email);
                // Setting emailBody
                intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body);
                using (var unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                {
                    using (var currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity"))
                    {
                        currentActivity.Call("startActivity", intentObject);
                    }
                }
            }
        }
    }
