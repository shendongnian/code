    List<Friends> friends = new List<Friend>();
    for (int x = 0; x <= 8; x++)
    {
        for (int i = 0; i < relSend.Length; i++)
        {
            WriteLine("{0}", relSend[i]);
            In[i] = Console.ReadLine();
        }
        friends.Add( new Friend() { Name = In[0]
                                  , Phone = int.Parse(In[1])
                                  , Month = int.Parse(In[2])
                                  , Day = int.Parse(In[3])
                                  , Year = int.Parse(In[4])
                                  }
                   );
    }
