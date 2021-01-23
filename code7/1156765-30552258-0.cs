          if (Drop)
            {
                Physics2D.IgnoreLayerCollision(8, 11);
                myGameObject.GetComponent<EdgeCollider2D>().enabled = false;
                myGameObject.GetComponent<EdgeCollider2D>().enabled = true;
            }
            else
            {
                Physics2D.IgnoreLayerCollision(8, 11, false);
            }
