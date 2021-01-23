    private Boolean uploadAnnounceDone = false;
    private void checkUpload()
    {
        String status = cases();
        if (status.Equals("uploading"))
        {
            if (!uploadAnnounceDone)
            {
                uploadAnnounceDone = true;
                PlayVoice(status);
            }
        }
        else
            PlayVoice(status);
    }
