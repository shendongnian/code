    private void OnLeaveSession()
    {
        long timestamp= (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
        string value = timestamp.ToString();
        PlayerPrefs.SetString("Time", value);
    }
    
    private void OnResumeSession()
    {
        long timestamp= (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
        string value = PlayerPrefs.GetString("Time");
        long oldTimestamp = Convert.ToInt64(value);
        long elapsedSeconds = timestamp - oldTimestamp;
        OnResumeSession(elapsedSeconds); // forward to listeners
    }
