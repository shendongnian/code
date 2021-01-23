    private void MyFunction<T>(T[] values)
    {
        for (int i = 0; i < values.Length; i++)
        {
            //Here is where the issue is, you can't constrain T to a value type that
            //defines mathematical operators, so the best you can do is dynamic:
            values[i] = (dynamic)values[i] * 5;
        }
    }
