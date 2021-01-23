    private void MyFunction(object values)
    {
        //Assume that object is an array, and go from there
        for (int i = 0; i < ((dynamic)values).Length; i++)
        {
            ((dynamic)values)[i] = ((dynamic)values)[i] * 5;
        }
    }
