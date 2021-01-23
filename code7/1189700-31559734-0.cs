    public void SetProgressText(string value) {
         if (this.InvokeRequired) {
             Action<string> progressDelegate = this.SetProgressText;
             progressDelegate.Invoke(value);
         } else {
             label_Progression.Text = value;
         }
    }
