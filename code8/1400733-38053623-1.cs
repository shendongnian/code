            float delayBetweenMoves = 5f;
            float lastMoveTime = 0f;
            bool isMovingLeft;
            public void Update(GameTime gameTime)
            {
                Move(gameTime);
                enemy.Position += (enemy.VelocityX * enemy.Speed);
            }
            private void Move(GameTime gameTime)
            {
                if(lastMoveTime < gameTime.TotalGameTime.TotalMiliseconds - TimeSpan.FromSeconds(delayBetweenMoves))
                {
                    lastMoveTime = gameTime.TotalGameTime.TotalMiliseconds;
                    if (isMovingLeft)
                    {
                        enemy.VelocityX = -1;
                        isMovingLeft = false;
                    }
                    else
                    {
                        enemy.VelocityX = +1;
                    }
                }
            }
