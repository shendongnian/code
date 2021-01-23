    if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
                {
                    Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    RaycastHit2D cubeHit = Physics2D.Raycast(cubeRay, Vector2.zero);
                    if (cubeHit)
                    {
                        //We hit something
                        if (cubeHit.collider.name == " ")
                        {
                            heldDown = true;
                        }
                    }
                }
