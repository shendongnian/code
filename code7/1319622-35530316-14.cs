    if (Input.GetMouseButtonDown(0))
      {
      // test carefully on all platforms
      if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
          return;
      Bingo();
      }
