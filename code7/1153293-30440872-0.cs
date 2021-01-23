    case MenuScreens.Playing:
                {
                    // This is allowing the player to go back to
                    // The main menu by pressing the escape key. 
                    KeyboardState keyState = Keyboard.GetState();
                    if (keyState.IsKeyDown(Keys.Escape))
                    {
                        menuState = MenuScreens.MainMenu;
                    }
                    //Updating the player1 and player2
                    p.Update(gameTime);
                    p2.Update(gameTime);
                    foreach (Darknut a in darknutList)
                    {
                        // Collision for player to darknut
                        // Note : If bounding box "a" (the darknut) comes into contact with boundingbox "p" (the player)
                        // Then darknut will be destroyed : BUT with reduction in player health. 
                        if (a.boundingBox.Intersects(p.boundingBox))
                        {
                            // Health of the player at "20" hitpoints. Every time the player gets hit by a darknut 
                            // take 20 pixels of the healthbar from 200 in total.
                            p.health -= 20;
                            // Make darknut invisable = deletion
                            a.isVisible = false;
                        }
                        // check to see if any darknuts come in contact with the arrows if so destroy arrow and darknut. 
                        for (int i = 0; i < p.arrowList.Count; i++)
                        {
                            // Returning the element at a specified element in the sequence
                            // Translate :  If any of the darknuts bounding box intersecs with the arrows bounding box 
                            // then destroy both by making the darknut and arrow invisible.  
                            if (a.boundingBox.Intersects(p.arrowList[i].boundingBox))
                            {
                                // when player hits darknut with arrow give them "X" score
                                hud.playerScore += 5;
                                a.isVisible = false;
                                p.arrowList.ElementAt(i).isVisible = false;
                            }
                        }
                        foreach (Darknut t in darknutList)
                        {
                            if (t.boundingBox.Intersects(p2.boundingBox))
                            {
                                // Health of the player at "20" hitpoints. Every time the player gets hit by a darknut 
                                // take 20 pixels of the healthbar from 200 in total.
                                p2.health -= 20;
                                // Make darknut invisable = deletion
                                t.isVisible = false;
                            }
                            for (int i = 0; i < p2.arrowList.Count; i++)
                            {
                                // Returning the element at a specified element in the sequence
                                // Translate :  If any of the darknuts bounding box intersecs with the arrows bounding box 
                                // then destroy both by making the darknut and arrow invisible.  
                                if (t.boundingBox.Intersects(p.arrowList[i].boundingBox))
                                {
                                    // when player hits darknut with arrow give them "X" score
                                    hud.playerScore2 += 5;
                                    t.isVisible = false;
                                    p2.arrowList.ElementAt(i).isVisible = false;
                                }
                            }
                            t.update(gameTime);
                        }
                        a.update(gameTime);
                        //t.update(gameTime);
                    }
                    // Loading Darknuts
                    LoadDarknuts();
                    // Loading Darknuts
                    //Updating the player
                    p.Update(gameTime);
                    //Updating the player2
                    p2.Update(gameTime);
                    // Updating the background
                    bg.Update(gameTime);
                    //  Updating the player health if it hits zero then go to gameover State
                    if (p.health <= 0)
                        menuState = MenuScreens.GameOver;
                    break;
                }
