    var jsonData = {
       "AppName":"SamplePrice",
       "AppInstanceID":"100",
       "ProcessGUID":"072af8c3-482a-4b1c‌​-890b-685ce2fcc75d",
       "UserID":"20",
       "UserName":"Jack",
       "NextActivityPerformers":{
            "39‌​c71004-d822-4c15-9ff2-94ca1068d745":
             [{
                "UserID":10,
                "UserName":"Smith"
             }]    //list nested in dictionary
       }
     }
    //call ajax post method
    ajaxPost:
    ...
    Content-Type: application/json,
    data: jsonData
    ...
    [HttpPost]
    public string ParseJsonComplex(dynamic data)
    {
       //compsite object type:
       var c = JsonConvert.DeserializeObject<YourObjectTypeHere>(data.ToString()); 
    
       //list or dictionary object type 
       var c1 = JsonConvert.DeserializeObject< ComplexObject1 >(data.c1.ToString());
    
       var c2 = JsonConvert.DeserializeObject< ComplexObject2 >(data.c2.ToString());
    
       ...
    }
