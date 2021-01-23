    private void btnNToOne_Click(object sender, EventArgs e)
    {
        int value = (int)numUpToThis.Value;
        Action<int> processResult = result =>
        {
            // Do whatever you like with the result
            textResult.Text = result.ToString();
        }
        Func<int, int, int> asyncCall = MyUtils.CalcPrim;
        asyncCall.BeginInvoke(value, 2, ar =>
        {
            // This is the callback called when the async call completed
            // First take the result
            int result = asyncCall.EndInvoke(ar);
            // Note that the callback most probably will called on a non UI thread,
            // so make sure to process it on the UI thread
            if (InvokeRequired)
                Invoke(processResult, result);
            else
                processResult(result);
        }, null);
    }
