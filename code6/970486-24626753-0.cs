    if(Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A))
            {
                if (pressKey)
                {
                    LoadModel("cube");
                    pressKey = false;
                }
            }
            if (Keyboard.GetState().IsKeyUp(Microsoft.Xna.Framework.Input.Keys.A))
            {
                pressKey = true;
            }
