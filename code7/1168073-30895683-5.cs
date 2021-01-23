    Dictionary<String, CallInformation> callDictionary = new Dictionary<String,CallInformation>();
    var csvLinesData = csvlines.Skip(1).Select(l => l.Split(',').ToArray());
    foreach(string[] parts in csvLinesData) {
         //Then place this call into a sortedlist or Dictionary. 
         //Here i am counting up the incoming and outgoing calls. 
         if(callDictionary.containsKey(parts[12])) {
             if(parts[4] == "I") {
                 callDictionary[parts[12]].InComingCount++;
             } else { 
                 callDictionary[parts[12]].OutGoingCount++; 
             }
         } else {
             //Construct your new object based on this row.
             CallInformation call = new CallInformation(parts);
             callDictionary.add(call.CSRName, call);
         }
    }
