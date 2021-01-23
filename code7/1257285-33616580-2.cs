    MessageServiceClient client1 = new MessageServiceClient();
    MessageServiceClient client2 = new MessageServiceClient();
    // ...
    for (int i = 0; i < 5; i++)
        client1.AddMessageToSession("msg" + i);
    client2.AddMessageToSession("msg" );
    int nbMessages1 = client1.ListSessionMessages().Count();
    int nbMessages2 = client2.ListSessionMessages().Count();
    // outputs 5 :
    Console.WriteLine("Number of messages in Session 1 : " + nbMessages1);
    // outputs 1 :
    Console.WriteLine("Number of messages in Session 2 : " + nbMessages2);
