    case State.Gameover:
                    {
                        //Get keyboard state
                        KeyboardState keyState = Keyboard.GetState();
                        if (keyState.IsKeyDown(Keys.Back))
                        {
                            if (IsHighScore())
                            {
                                highScore = playerScore;
                                
    /////////////////////////  HERE  ///////////////////////////////////////////
    SavehighScore("HighScoreFileName.txt");
    }
                        playerScore = 0;
                        sharks.Clear();
                        crew.Clear();
                        gameState = State.Menu;
                    }
                    break;
                }
