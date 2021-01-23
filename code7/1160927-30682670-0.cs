    public static unsafe void CallXFunction(int a, sbyte[][] array)
    {
        var pointerArray = new sbyte*[array.Length];
        
        // Recursive fixing so that whole array get's pinned at same time   
        // (never use fixed pointer outside of fixed{} statement)
        Action<int> fixArray = null;   
        fixArray = (pos) =>
        {
            fixed (sbyte* ptr = array[pos])
            {
                pointerArray[pos] = ptr;
                if (pos <= (array.Length - 2))
                {
                    fixArray(pos + 1);
                }
                else
                {
                    fixed (sbyte** pointer = pointerArray)
                    {
                        XFunction(a, pointer);
                    }
                }
            }
        };
        fixArray(0);
    }
