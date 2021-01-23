    private static void Resize<T>(ref T[] array,int size)
    {
        array = array.Take(size).ToArray(); // attempt to take first n elements
        T[] temp = new T[size]; // create new reference
        array.CopyTo(temp, 0); // copy array contents to new array
        array = temp; // change reference
    }
