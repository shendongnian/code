    private void UpdateProgress(int percent)
    {
      if (Restore.frmRestore.progressBar1.InvokeRequired)
      {
        UpdateProgress.Invoke(percent);
      }
      else
      {
        Restore.frmRestore.progressBar1.Value = percent;
      }
    }
