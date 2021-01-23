    var indices = new[] { 2, 3 };                
    var arr = Array.CreateInstance(typeof(int), indices);
    var value = 1;
    for (int i = 0; i < indices[0]; i++)
    {
        for (int j = 0; j < indices[1]; j++)
        {
            arr.SetValue(value++, new[] { i, j });
        }
    }
    //arr = [ [ 1, 2, 3 ], [ 4, 5, 6 ] ]
