    private UserData DeserializeUserData(byte[] data)
    {
        byte[] decryptedSerializedData = logic.Decrypt(data);
        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream(decryptedSerializedData))
        {
            return bf.Deserialize(ms) as UserData;
        }
    }
    private byte[] SerializeUserData(UserData userData)
    {
        byte[] userDataArray;
        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            bf.Serialize(ms, userData);
            userDataArray = ms.ToArray();
        }
        return logic.Encrypt(userDataArray);
    }
