    case State.Gameover:
                        {
                            //Get keyboard state
                            KeyboardState keyState = Keyboard.GetState();
                            if (keyState.IsKeyDown(Keys.Back))
                            {
                                if (IsHighScore)
                                {
                                    highScore = playerScore;
                                    SavehighScore();
                                }
                                playerScore = 0;
