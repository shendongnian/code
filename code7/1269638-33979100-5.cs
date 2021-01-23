    [Fact]
    public void SMSMessage()
    {
      Message msg = YourClass.create("S123456789+123456789012");
      Assert.IsType<Sms_Message>(msg);
      Assert.Equal("123456789+123456789012", msg.Body);
    }
