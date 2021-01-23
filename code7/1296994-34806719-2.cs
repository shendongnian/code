    if (useFullProces)
    {
        resultNames= result.Select(x=>x.ID).ToList();  
    }
    else
    {
        resultNames = result.Select(x=>x.Name).ToList();
    }
