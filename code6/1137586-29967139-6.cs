    bool DoSomething (Arguments args)
    {
      bool success = false;
      if (someaction)
      {
        args.Arg = new Myclass;
        success = true;
      }
      return success;
    }
