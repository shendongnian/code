    private void PerformStep()
    {
        if (progressBar1.InvokeRequired)
        {
               progressBar1.Invoke(
                 new MethodInvoker(() => progressBar1.PerformStep()));
        }
        else
        {
             progressBar1.PerformStep();
        }
}
