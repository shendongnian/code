	public string GetFileName(string fileName)
	{ 
      if(fileName.Contains("$track") && 
         !String.IsNullOrEmpty(musicInfo.Tag.Track.ToString())
        {
            return fileName.Replace("$track", musicInfo.Tag.Track.ToString());
        }
         
         var userOption = System.Windows.Forms.MessageBox.Show(
         "Error: Track # missing from tag info", "Error", 
         System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore, 
         System.Windows.Forms.MessageBoxIcon.Error)
         
        switch(userOption) 
        {
		  case System.Windows.Forms.DialogResult.Abort:
		      return  "ABORTED";
		  case System.Windows.Forms.DialogResult.Retry:
		      return GetFileName(fileName);
		  case System.Windows.Forms.DialogResult.Ignore:
			  return fileName.Replace("$track", "");
         }
	}
