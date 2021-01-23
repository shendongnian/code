           SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
           bulkcopy.DestinationTableName = ssqltable;
           bulkcopy.BatchSize=100;
           bulkcopy.WriteToServer(dr);
           
