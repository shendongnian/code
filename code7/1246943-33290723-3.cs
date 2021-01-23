     switch(currentSpriteState)
    {
      case SpriteState.Left:
       spriteBatch.Draw(moveLeft, Position, null, Color.White, 0f,
       Vector2.Zero, 1f, SpriteEffects.None, 0f);
      break;
      case SpriteState.Right:
       spriteBatch.Draw(moveRight, Position, null, Color.White, 0f,
       Vector2.Zero, 1f, SpriteEffects.None, 0f);
      break;
      case SpriteState.Straight:
       spriteBatch.Draw(PlayerTexture, Position, null, Color.White, 0f,
       Vector2.Zero, 1f, SpriteEffects.None, 0f);
      break;
    }
