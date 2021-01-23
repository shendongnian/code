    if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
      {
                Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                RaycastHit2D cubeHit = Physics2D.Raycast(cubeRay, Vector2.zero);
                if (cubeHit)
                {
                    //We hit something
                    Debug.Log(cubeHit.transform.gameObject.name);
                    if (this.target != null)
                    {
                        SelectMove sm = this.target.GetComponent<SelectMove>();
                        if (sm != null) { sm.enabled = false; }
                    }
                    target = cubeHit.transform.gameObject;
                    //Destroy(cubeHit.transform.gameObject);
                    selectedPlayer();
                }
      }
