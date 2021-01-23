            if (Input.GetKey(KeyCode.Space))
            {
                initialForce += 0.1f;
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
                Instantiate(RedBall, firePoint.position, firePoint.rotation);
            }
            else
            {
                if (initialForce > 0)
                {
                    var ball = Instantiate(RedBall, firePoint.position, firePoint.rotation);
                    ball.GetComponent<Rigidbody2D>.AddForce(firePoint.rotation * Vector2.one * initialForce);
                }
                initialForce = 0f;
            }
