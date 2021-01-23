    this.InitializeJaggedArray(w, 5, 3);
    ....
    private double[][][] w = new double[3][][];
    private void InitializeJaggedArray(IList arr, object initializeValue, int neuronSize)
    {
        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i] == null)
            {
                arr[i] = Activator.CreateInstance(arr.GetType().GetElementType(), new object[] { neuronSize } );
            }
    
            if(arr[i] is IList)
            {
                InitializeJaggedArray(arr[i] as IList, initializeValue, neuronSize);
            }
            else
            {
                arr[i] = initializeValue;
            }
        }
    }
