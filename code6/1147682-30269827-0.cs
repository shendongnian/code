    public int success_fail
    IEnumerator POST(string username, string passw)
    {
        WWWForm form = new WWWForm();
        form.AddField("usr", username);
        form.AddField("pass", passw);
        WWW www = new WWW(url, form);
        yield return StartCoroutine(WaitForRequest(www));
    }
    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            if(www.text.Contains("user exists"))
                {
                    success_fail = 2;
                }
                else
                {
                    success_fail=1;
                }
        } else {
            success_fail=0;
        }    
    }
