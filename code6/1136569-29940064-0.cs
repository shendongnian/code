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
