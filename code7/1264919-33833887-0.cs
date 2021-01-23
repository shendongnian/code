    double MyNewFunction(Vector v1, Vector v2) 
    {
        // your code here, as an example here is the matrix multiplication
        double returnValue;
        if (v1.Count!= v2.Count) 
        {
            // process error
        }
        for (int i = 0; i< v1.Count; i++) 
        {
            returnValue += v1.Item[i] * v2.Item[i];
        }
        return returnValue;
    }
