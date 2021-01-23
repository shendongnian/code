    public class FakeClient : SoapHttpClientProtocol
    {
        public static Mock<SoapHttpClientProtocol> Mock { get; set; }
    
        public override object GetData() => Mock.Object.GetData();
    
        public override object SendData(object data) => Mock.Object.SendData(data);
    }
    
    [TestMethod]
    public void Function1Test()
    {
        FakeClient.Mock = new Mock<SoapHttpClientProtocol>();
        FakeClient.Mock.Setup(mock => mock.GetData()).Returns(...));
        FakeClient.Mock.Setup(mock => mock.SendData(It.IsAny<object>())).Callback(...));
    
        WebServicesManager.Function1<FakeClient>();
    }
