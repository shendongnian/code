    public static EventsXM{
        public static RegisterSomeTypeNotification(Action<sometype> Callback){
             userControl1.NewType +=(o,s)=>{
                   Callback(s);
             }
        }
        public static NotifyNewData(this sometype data){
             if(usercontrol1.NewType!=null){
                  usercontrol1.NetType(data)
             }
        }
    }
   
    //to use the XM
    sometype.NotifyNewData();  //will send notification
    RegisterSomeTypeNotification(data=>{
      //data has the value of sometype here... and is called only when new data arrives
    });
