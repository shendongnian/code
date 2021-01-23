    string bytesToGet = string.empty;
    switch (listbox.Text){
        case "H01":
             bytesToGet = "01P00101##";
        case "H02":
             bytesToGet = "02P00101##";
    }
    content.AddRange(Encoding.ASCII.GetBytes(bytesToGet));
