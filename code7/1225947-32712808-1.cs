    private void HandleBeforeRequest(Session oSession)
    {
        oSession.bBufferResponse = true;
    }
    private void HandleBeforeResponse(Session oSession)
    {
        if(oSession.fullUrl.Contains("google.com"))
        {
            richTextBox1.Invoke(new UpdateUI(() =>
            {
                richTextBox1.AppendText(oSession.GetResponseBodyAsString());
            }));
        }
    }
