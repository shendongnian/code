    public class Lifetouch
    {
        public int LifetouchID { get; set; }
        public string Data { get; set; }
    }
    
    public class Lifetemp
    {
        public int LifetempID { get; set; }
        public string Data { get; set; }
    }
    
    main()
    {
        getPerodicListofVitalSigns <Lifetouch>(new Lifetouch());  
        getPerodicListofVitalSigns <Lifetemp>(new Lifetemp());
    }
    public static void getPerodicListofVitalSigns <T>( T clazz)
    {
        List<T> list_of_measurements_Original = JsonConvert.DeserializeObject<List<T>>(json_response);
    
        // Got the list_of_measurements_Original count 2.
    
        StringBuilder sb = new StringBuilder();
        sb.Append("[");
    
        foreach (var element in list_of_measurements_Original)
        {
             if (VitalSignName == "Lifetouch")
                                {
                                    var vitalSign = element as Lifetouch;
                                    dataString = dataString + (vitalSign.LifetouchID + ",");
                                }
                                else if (VitalSignName == "Lifetemp")
                                {
                                    var vitalSign = element as Lifetemp;
                                    dataString = dataString + (vitalSign.LifetempID + ",");
                                }
        }
        sb.Append("]");
        
        string WebserviceAddress = "192..../json/reply/UpdateSyncStatus";
        JSON_POST_Sender.ClassPost(WebserviceAddress, dataString), "true")
     }
