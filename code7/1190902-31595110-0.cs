           SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
           bulkcopy.DestinationTableName = ssqltable;
           while (dr.Read())
           {
              bulkcopy.WriteToServer(dr);
           }
