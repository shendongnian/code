    bool wasThrown = false;
    IWebRequestCreate m_testWebRequestCreateCorrectDevices = null;
    [TestMethod]
    public void TestThreadedWebRequest()
    {
        const string errorResponse = "Some Error Text";
        m_testWebRequestCreateCorrectDevices = new TestWebRequestCreate();
        var uri = new Uri(@"http:\\www.stackoverflow.com");
        wasThrown = false;
        var thread = new System.Threading.Thread(() =>
            {
                while (true)
                {
                    var creator = m_testWebRequestCreateCorrectDevices;
                    if (creator != null)
                    {
                        var message = creator.Create(uri); 
                        var response = new StreamReader(message.GetResponse()
                                                          .GetResponseStream()).ReadToEnd();
                        if (response == errorResponse)
                        {
                            wasThrown = true;
                            break;
                         }
                    }
                    System.Threading.Thread.Sleep(500);
                }
            });
        thread.Start();
        System.Threading.Thread.Sleep(5000);
        Assert.AreEqual(false, wasThrown);
        m_testWebRequestCreateCorrectDevices = null;
        m_testWebRequestCreateCorrectDevices = new TestWebRequestCreate
        {
            testWebRequest = new TestWebRequest(HttpStatusCode.OK, errorResponse)
        };
        System.Threading.Thread.Sleep(5000);
        Assert.AreEqual(true, wasThrown);
        if (!thread.Join(1000))
        {
            thread.Abort();
        }
    }
