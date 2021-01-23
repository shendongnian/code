    var hexBytes = "4E 4F 54 49 46 59";
    var bytes = hexBytes.Split(' ')
        .Select(hb => Convert.ToByte(hb, 16)) // converts string -> byte using base 16
        .ToArray();
    var asciiStr = System.Text.Encoding.ASCII.GetString(bytes);
