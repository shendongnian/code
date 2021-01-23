        try
        {
            if(!string.IsNullOrEmpty(workSheet.Cells[rowIterator, 13].Value.ToString()))
            {
                store.OpenTime = workSheet.Cells[rowIterator, 13].Value.ToString();
            }
        }
        catch(NullReferenceException)
        {
           store.OpenTime = SomeValue;
        }
