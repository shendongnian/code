    var data = {
       "Groups": [
                      {
                           ...
                      }
        
                 ]
        }
    var toDelete = "Nani" // change by what you want
    for (i = 0; i < data.Groups[0].Members.length; i++){
        if(data.Groups[0].Members[i].UniqueId == toDelete){
            delete data.Groups[0].Members[i]
            break;
        }
    }
