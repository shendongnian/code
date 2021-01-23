      public static void Register(string actionName, UnityAction<Dictionary<string, Object>> handler)
      {
        switch(actionName)
        {
          case "battle":
            _battleEvents.AddListener(handler);
            break;
          default:
            Debug.Log("Error");
            break;
        }
      }
