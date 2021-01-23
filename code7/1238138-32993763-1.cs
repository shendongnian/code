    User user=new User();
    using(StreamWriter sw=new StreamWriter(/*Filename goes here*/))
    {
      using(BinaryFormatter bformatter=new BinaryFormatter())
      {
        bformatter.Serialize(sr, user);
      }
    }
    using(StreamReader sr=new StreamReader(/*Filename goes here*/))
    {
      using(BinaryFormatter bformatter=new BinaryFormatter())
      {
        user=(User)bformatter.Deserialize(sr);
      }
    }
