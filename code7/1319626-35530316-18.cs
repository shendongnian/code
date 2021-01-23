    if (Input.GetMouseButtonDown(0)) { // doesn't really work...
      if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
          return;
      Bingo();
      }
