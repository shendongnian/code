    public static void Post(string RequestURL, string Post1, string Post2)
    {
        using (var wb = new WebClient())
        {
            var data = string.Format("{0}\"{1}\":\"{2}\"{3}", "{", Post1, Post2, "}");
            var response = wb.UploadString(RequestURL, "POST", data);
        }
    }
