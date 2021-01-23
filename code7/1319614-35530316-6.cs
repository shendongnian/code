    if (Input.GetMouseButtonDown(0))
      {
      // possibly does not work on Android
      if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
          return;
      Bingo();
      }
