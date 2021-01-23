            int i = 1;
            foreach (item x in bigList)
            {
                
                batchOperation.Insert(x); //replace it with your action; create the batch
                i++;
                if (i >100)
                {
                    table.ExecuteBatch(batchOperation); //execute the batch
                    batchOperation.Clear();
                    i = 1; // re-initialize 
                }
            }
            if (batchOperation.Count >= 1 )
            {
                table.ExecuteBatch(batchOperation);
            }
