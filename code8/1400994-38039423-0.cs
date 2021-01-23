    public List<string> GetImages(string baseAddress, DateTime startDate, DateTime endDate) {
            var imageList = new List<string>();
            while (startDate < endDate) {
                var dateString = startDate.ToString("yyyymmdd");
                var timeString = startDate.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                imageList.Add($"{baseAddress}_{dateString}_{timeString}.png"); //C# 6.0 feature.
                startDate = startDate.AddMinutes(10);
            }
            return imageList;
    }
