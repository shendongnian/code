    graphics.EnumerateMetafile(emfPlusMetaFile, new PointF(0, 0),
        (recordType, flags, dataSize, data, callbackData) =>
        {
            var dataArray = GetDataArray(data, dataSize);
            AdjustWorldTransformScale(recordType, dataArray, 0.75f);
            emfPlusMetaFile.PlayRecord(recordType, flags, dataSize, dataArray);
            return true;
        }
    );
    private static void AdjustWorldTransformScale(EmfPlusRecordType recordType, byte[] dataArray, float wtfScale)
    {
        if (recordType == EmfPlusRecordType.SetWorldTransform)
        {
            using (var stream = new MemoryStream(dataArray))
            using (var reader = new BinaryReader(stream))
            using (var writer = new BinaryWriter(stream))
            {
                var m11 = reader.ReadSingle();
                var m12 = reader.ReadSingle();
                var m21 = reader.ReadSingle();
                var m22 = reader.ReadSingle();
                stream.Position = 0;
               
                writer.Write(m11*wtfScale);
                writer.Write(m12*wtfScale);
                writer.Write(m21*wtfScale);
                writer.Write(m22*wtfScale);                
            }
        }
    }
    private static byte[] GetDataArray(IntPtr data, int dataSize)
    {
        if (data == IntPtr.Zero) return null;
        
        // Copy the unmanaged record to a managed byte buffer that can be used by PlayRecord.
        var dataArray = new byte[dataSize];
        Marshal.Copy(data, dataArray, 0, dataSize);
        return dataArray;
    }
