      public static Order GetOrder(OrderInformation orderInfo, Logger logger, string overlayPath)
        {
            return mTypeConstructors[orderInfo.Type](orderInfo, logger, overlayPath);           
        }
      private static readonly Dictionary<OrderType, Func<OrderInformation, Logger, string, Order>>
      mTypeConstructors = new Dictionary<OrderType, Func<OrderInformation, Logger, string, Order>>
                   {
                     { OrderType.Print, Print.Create },
                    ///...
    
                   };
       public class Print : Order
        {
            ...
    
            public static Print Create(OrderInformation orderInfo, Logger logger, string overlayPath)
            {
               ...
            }
 
