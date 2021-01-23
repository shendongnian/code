    public class GolldysNetworkInfomation : INetworkInfomation
    {
       NetworkInfomation networkInformation;
    }
    public class SystemUnderTest
    {
        public SystemUnderTest(INetworkInfomation networkInfomation)
        {
        }
    }
