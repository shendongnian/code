    public T MemoryRead<T>(int baseAdresse, params int[] offsets) 
    {
         
        if(!ProcessExists())
            return default(T);
    
        uint size = 0;
    
        if(typeof(T) == typeof(int)) {
            size = sizeof(int);
            return (T)(object)MemoryRead<int>(baseAdresse, size, offsets);
    
        } else if(typeof(T) == typeof(float)) {
            size = sizeof(float);
            return (T)(object)MemoryRead<float>(baseAdresse, size, offsets);
                    
        } else if(typeof(T) == typeof(double)) {
            size = sizeof(double);
            return (T)(object)MemoryRead<double>(baseAdresse, size, offsets);
                    
        }else {
    
            MessageBox.Show("Wrong type. Maybe you want to use MemoryRead<string>(int, uint, params [] int)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw new ArgumentException("Wrong type. Maybe you want to use MemoryRead<string>(int, uint, params [] int)");
    
        }
    }
