    public void MyPluginMain(ISqlConnectionFactory factory)
    {
       using(var connection = factory.GenerateConnection())
       {
          // Do the work
       }
    }
