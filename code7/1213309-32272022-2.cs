       ...
       if (j == 2)
       {
            // not store the value when j is 2.
           data.colValues = new Nullable<Double>(); // or (Double?) null;
       }
       else
       {
           data.colValues = (Double?) (12.2 * j);                  
       }
       ...
       // if colValue exists
       if (null != data.colValues) {
         Double v = data.colValues;
         ... 
       }
