    class processor
    {
       IExampleInterface parser;
       event MyEventHandler MyEvent
       {
          add { parser.MyEvent += value; }
          remove { parser.MyEvent -= value; }
       }
