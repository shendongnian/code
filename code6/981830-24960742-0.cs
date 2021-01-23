    foreach (Platform a in platformList.OrderByY())
    {
        if (player.collisionRect.isOnTopOf(a.rectangle) && player.velocity.Y>=0)
        {
            player.hasJumped = false;
            player.velocity.Y = 0f;
            if(player.collisionRect.Bottom > a.rectangle.Top || player.collisionRect.Bottom - a.rectangle.Top <=10)
            {
                player.position.Y = a.rectangle.Y - 48 / 2;
                player.hasJumped = false;
            }
            break;
        }
        else
        {
            player.hasJumped = true;
        }
    }
