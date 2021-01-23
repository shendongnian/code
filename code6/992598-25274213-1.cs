    public interface ISerialize<T>
    {
        byte[] Serialize();
        T Deserialize( byte[] data );
    }
