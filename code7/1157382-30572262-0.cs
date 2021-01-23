    public class AmortizationDepotResult ... 
      IClonable {
    
      ...
      Object IClonable.Clone() {
        return Clone();
      }
    
      public AmortizationDepotResult Clone() {
        AmortizationDepotResult result = new AmortizationDepotResult();
        ...    
        result.Payment = Payment;
        ...
    
        return result;
      }
    }
