        /*
         * SmartPhone<-Technician friendship contract
         */
        public class SmartPhoneServiceActivities
        {
            public delegate bool ReplaceGlassHandler  (SmartPhone device);
            public delegate bool ReplaceDisplayHandler(SmartPhone device);
            public ReplaceGlassHandler   ReplaceGlass {get;}
            public ReplaceDisplayHandler FactoryReset {get;}
            public SmartPhoneServiceActivities(ReplaceGlassHandler replaceGlass, ReplaceDisplayHandler factoryReset)
            {
                ReplaceGlass = replaceGlass;
                FactoryReset = factoryReset;
            }
        }
        //-------------------------------------------------------------------------------
        public class SmartPhone
        {
            #region Friend functions
            /*
             * Provide private functions for "trusted" classes
             */
            static SmartPhone()
            {
                var services = new SmartPhoneServiceActivities(ReplaceGlass, FactoryReset); // SmartPhone<-Technician agreement regarding "private modifications"
                Technician.RegisterDeviceForRepair(typeof(SmartPhone), services);
            }
                    
            protected static bool ReplaceGlass(SmartPhone device)
            {
                device.IsDamagedGlass = false;
                return true; // Skilled technicians only ;)
            }
            protected static bool FactoryReset(SmartPhone device)
            {
                device.IsDamagedSoftware = false;
                return true;
            }
            #endregion
            #region Standard public usage
            public bool IsDamaged => IsDamagedGlass || IsDamagedSoftware;
            public bool IsDamagedGlass    {get; protected set;}
            public bool IsDamagedSoftware {get; protected set;}
            public void Call() {}
            public void DropIt()
            {
                var isBroken = (new Random((int)(DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds)).Next() & 3;
                IsDamagedGlass    = (isBroken & 1) != 0;
                IsDamagedSoftware = (isBroken & 2) != 0;
            }
            #endregion
        }
        // --------------------------------------------------------------------------------
        public class Technician
        {
            protected static readonly Dictionary<Type, SmartPhoneServiceActivities> knowHow = new Dictionary<Type, SmartPhoneServiceActivities>();
            /*
             * Although this is public and improper call might cause inability of a class to register it's acceptable "risk". 
             * It's intended for static constructors invocation.
             */
            public static void RegisterDeviceForRepair(Type deviceType, SmartPhoneServiceActivities services)
            {
                if (   (!knowHow.ContainsKey(deviceType))
                    && (services != null))
                {
                    knowHow[deviceType] = services;
                }
            }
            public bool Repair(SmartPhone device)
            {
                var isRepaired = false;
                var deviceType = device.GetType();
                if (knowHow.ContainsKey(deviceType))
                {
                    var services  = knowHow[deviceType];
                    var isSoftOk  = !device.IsDamagedSoftware || services.FactoryReset(device);
                    var isGlassOk = !device.IsDamagedGlass    || services.ReplaceGlass(device);
                    
                    isRepaired = isSoftOk && isGlassOk;
                }
                   
                return isRepaired; 
            }
        }
