      Redemption.RDOSession rSession = new Redemption.RDOSession();
      Redemption.RDOMail Msg = rSession.CreateMessageFromMsgFile("c:\Temp\TestMsg.msg");
      Msg.Body = "This is a test template";
      Msg.Subject = "Template";
      Msg.Save();
      Msg.SaveAs("c:\Temp\TestTemplate.oft", Redemption.rdoSaveAsType.olTemplate);
