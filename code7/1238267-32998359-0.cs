    using UnityEngine.EventSystems;
    ...
    if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
    {
        if(EventSystems.EventSystem.current.IsPointerOverGameObject()) {
              Debug.Log("UI hit!");
        }
    }
