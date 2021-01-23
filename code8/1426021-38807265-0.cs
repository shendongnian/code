    //Load the assembly
    Assembly dll =
        Assembly.Load(
            @"System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 ");
    //Get the MessageBox type
    Type msBox = dll.GetType("System.Windows.Forms.MessageBox");
    //Finally invoke the Show method
    msBox
        .GetMethod(
            "Show",
            //We need to find the methods that takes two string parameters
            new [] {typeof(string), typeof(string)})
        .Invoke(
            null, //For static methods
            new object[] { "Hi", "Message" });
