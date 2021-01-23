    Health health = new Health(3, "Sprites/spr_health");
    if (this.CollidesWith(player) && this.Visible)
        foreach (GameObject obj in gameObjects)
        {
            SpriteGameObject h = obj as SpriteGameObject;
            {
                gameObjects.Remove(h);
            }
        }
