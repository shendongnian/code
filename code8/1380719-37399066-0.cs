    void Start()
    {
      if (Application.isMobilePlatform)
      {
          ScrollRect scrolRect = GameObject.Find("GameObjectScrollRectIsAttachedTo").GetComponent<ScrollRect>();
          scrolRect.scrollSensitivity = 0.5f;
          scrolRect.elasticity = 0.05f;
          scrolRect.decelerationRate = 0.2f;
      }
    }
