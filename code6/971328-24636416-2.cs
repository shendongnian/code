    public override void Write(byte[] buffer, int offset, int count) {
        //... Removed Error checking for example
 
        int i = _position + count;
        // Check for overflow
        if (i < 0)
            throw new IOException(Environment.GetResourceString("IO.IO_StreamTooLong"));
 
        if (i > _length) {
            bool mustZero = _position > _length;
            if (i > _capacity) {
                bool allocatedNewArray = EnsureCapacity(i);
                if (allocatedNewArray)
                    mustZero = false;
            }
            if (mustZero)
                Array.Clear(_buffer, _length, i - _length);
            _length = i;
        }
        
        //... 
    }
    private bool EnsureCapacity(int value) {
        // Check for overflow
        if (value < 0)
            throw new IOException(Environment.GetResourceString("IO.IO_StreamTooLong"));
        if (value > _capacity) {
            int newCapacity = value;
            if (newCapacity < 256)
                newCapacity = 256;
            if (newCapacity < _capacity * 2)
                newCapacity = _capacity * 2;
            Capacity = newCapacity;
            return true;
        }
        return false;
    }
