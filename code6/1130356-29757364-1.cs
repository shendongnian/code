    public List<T> Open(string filename) where T: class
            {
                BinSerializerUtility binSerial = new BinSerializerUtility();
                return binSerial.BinaryFileDeSerialize<T>(filename); 
    
            }
