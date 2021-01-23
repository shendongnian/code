    public static IEnumerable<object[]> ValidSMSMessages()
    {
      yield return new object[] { "123456789-123456789012" }
      yield return new object[] { "123456912-123456789012" }
      yield return new object[] { "123672389-123456789012" }
      yield return new object[] { "121233789-123456789012" }
      yield return new object[] { "123456789-123456781212" }
      yield return new object[] { "123456789-121216789012" }
      // One could probably think of better examples here based on a mixture of realistic and edge-case uses.
    }
    [Theory]
    [MemberData("ValidSMSMessages")]
    public void SMSMessages(string smsBody)
    {
      Message msg = YourClass.create("S" + smsBody);
      Assert.IsType<Sms_Message>(msg);
      Assert.Equal(smsBody, msg.Body);
    }
