    public interface IPowerpointExporter
    {
        void AddSlides(int amount);
    
        void setTitle(string title);
    }
    ....
    [TestMethod]
    public void testPPTObject()
    {
        var mockPPT = new Mock<IPowerpointExporter>();
        mockPPT.Setup(m => m.AddSlides(1)).Verifiable();
    
        ExportPowerPoint temp = (ExportPowerPoint)mockPPT.Object;
        temp.AddSlides(1);
        mockPPT.VerifyAll();
    }
