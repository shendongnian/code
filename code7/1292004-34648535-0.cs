    string[] formats = new string[] {"d/M/yyyy", "d-M-yyyy"}; //notice the dash
    DateTime biggest = lst
            .Select(x => DateTime.ParseExact(x.time, formats, //now use formats here
                        System.Globalization.CultureInfo.InvariantCulture, 
                        System.Globalization.DateTimeStyles.AssumeLocal)) //to get the list of `string` of `time` from your List<DTOSaveFromFile> + //To convert it to DateTime 
            .Max(); //Get the max among the DateTime
