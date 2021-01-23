            if (kb.IsKeyDown(Keys.W) || kb.IsKeyDown(Keys.A) || kb.IsKeyDown(Keys.S) || kb.IsKeyDown(Keys.D))
            {
                velocity = Vector2.Zero;
                if (kb.IsKeyDown(Keys.W))
                    velocity.Y = -movespeed;
                if (kb.IsKeyDown(Keys.A))
                    velocity.X = -movespeed;
                if (kb.IsKeyDown(Keys.S))
                    velocity.Y = movespeed;
                if (kb.IsKeyDown(Keys.D))
                    velocity.X = movespeed;
            }
            else
                velocity *= .9f;
