    public enum InfoType {
      Name,
      Nickname,
      Age
    }
    
    pubic void Decision(InfoType type, string input)
    {
        switch (type)
        {
          case InfoType.Name:
            Name = input;
            break;
          case InfoType.NickName:
            NickName = input;
          break;
        }
    }
