    public static byte ComputeAdditionChecksum(List<byte> data)
    {
        byte sum = 0;
        unchecked // Let overflow occur without exceptions
        {
            for (var i = 0; i < data.Length - 1;  i++)
            {
                sum -= data[i];
            }
        }
        return sum;
    }
