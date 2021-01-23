    for (int i = 0; i < nrdaily.Rows.Count; i++)
    {
         string time = nrdaily.Rows[i][3].ToString();
         if (time.Length == 5)
              time = "00:" + time;
         double NRT = TimeSpan.Parse(time).TotalSeconds;
         nrdaily.Rows[i][3] = NRT;
    }
