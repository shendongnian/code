    interface IConfiguration
    { 
        void somefunc();
    }
    interface IEquipmentManager
    {
        void someOtherFunc();
    }
    class BaseCore
    {
       private IConfiguration conf;
       private IEquipmentmanager eq;
       private BaseCore(){};
       
       public BaseCore(IConfiguration inConf, IEquipmentmanager inEq) :
              conf(inConf), eq(inEq)
      {
        conf.someFunc();
      }
       
    }
    class AConf : IConfiguration
    {
       public void someFunc()
       {
            do stuff!
       }
    }
    class AEq : IEquipmentmanager
    {
       public void someOtherFunc()
       {
            do stuff!
       }
    }
