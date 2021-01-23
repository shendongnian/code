    var txt = "Name of House: Aasleagh Lodge\r\nTownland: Srahatloe\r\nNear: Killary Harbour, Leenane\r\nStatus/Public Access: maintained, private fishing lodge\r\nDate Built: 1838-1850, burnt 1923, rebuilt 1928";
    var splts = txt.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(p => 
                     new
                     {
                       key1 = p.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries)[0],
                       value1 = p.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries)[1]
                     })
                   .ToDictionary(v => v.key1, v => v.value1);
    // Then, you can access the values like this:
    var nameValue = splts["Name of House"];
    var townValue = splts["Townland"];
