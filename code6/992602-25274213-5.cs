    public interface ISerialize<out T>
    {
        byte[] Serialize();
        T Deserialize( byte[] data );
    }
