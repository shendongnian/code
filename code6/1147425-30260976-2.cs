      Vector3 eulerAngles = transform.eulerAngles;
      if (Input.GetKeyDown(KeyCode.W))
         eulerAngles.x += 10;
      if (Input.GetKeyDown(KeyCode.S))
         eulerAngles.x -= 10;
      if (Input.GetKeyDown(KeyCode.A))
         eulerAngles.y += 10;
      if (Input.GetKeyDown(KeyCode.D))
         eulerAngles.y -= 10;
      transform.eulerAngles = eulerAngles;
