    namespace ReflectorLike.Tests
    {
        [TestFixture]
        internal class ChatHubTester
        {
            [SetUp]
            public void SetUp()
            {
                var request = Substitute.For<IRequest>();
                request.User.Identity.Name.Returns("IdentityName");
    
                var clients = Substitute.For<IHubCallerConnectionContext<ExpandoObject>>();
                clients.Group("groupName").Returns(new ExpandoObject());
    
                var groupManager = Substitute.For<IGroupManager>();
    
                context = Substitute.For<HubCallerContext>(request, "123");
                context.ConnectionId.Returns(rank.ToString(CultureInfo.InvariantCulture));
    
                myMockedClient = Substitute.For<IChatService>();
                myMockedClient.When(x => x.RemoveUser(Arg.Any<ChatUser>())).DoNotCallBase();
                myMockedClient.When(x => x.SendNewMessage(Arg.Any<ChatMessage>())).DoNotCallBase();
                var testList = new List<ChatMessage> { new ChatMessage { Message = "Test Message", User = new ChatUser{ UserName = "LastUser"}} }.ToArray();
                myMockedClient.GetNewMessages(Arg.Any<ChatUser>()).Returns(testList);
    
    
                UpdateClientConnect(false);
    
                hub = Substitute.ForPartsOf<ChatHub>(myMockedClient, context, groupManager);
                hub.When(x => x.Broadcast(Arg.Any<ChatMessage>())).DoNotCallBase();
                hub.When(x => x.EmitTo(Arg.Any<string>(), Arg.Any<ChatMessage>())).DoNotCallBase();
            }
    
            public void UpdateClientConnect(bool last)
            {
                myMockedClient.ClientConnect(Arg.Any<string>()).Returns(new ChatUser { UserName = "TestUser" + rank }).AndDoes(x =>
                                                                                                                               {
                                                                                                                                   context.ConnectionId
                                                                                                                                          .Returns(
                                                                                                                                                   rank
                                                                                                                                                       .ToString
                                                                                                                                                       (CultureInfo
                                                                                                                                                            .InvariantCulture));
                                                                                                                                   if (!last)
                                                                                                                                   {
                                                                                                                                       rank ++;
                                                                                                                                   }
                                                                                                                               });
            }
    
            private HubCallerContext context;
            private IChatService myMockedClient;
            private ChatHub hub;
            private static int rank;
            private const bool LAST = true;
            private const bool NOTLAST = false;
    
            [Test]
            public void Connect()
            {
                hub.Connect("0");
                UpdateClientConnect(LAST);
                hub.Connect("1");
    
                int i = 0;
                foreach (ICall call in hub.ReceivedCalls())
                {
                    Assert.AreEqual("TestUser" + i + " connected", ((ChatMessage)(call.GetArguments()[0])).Message);
                    Assert.AreEqual("SYSTEM", ((ChatMessage)(call.GetArguments()[0])).User.UserName);
                    i++;
                }
                Assert.AreEqual(2, i); // 2 items
            }
        }
    }
