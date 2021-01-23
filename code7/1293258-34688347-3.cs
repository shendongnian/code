            foreach (OvalShapeBullet b in Bullets)
            {
                if (b.TryMoveToTarget(bulletSpeed))
                {
                    // handle bullet has hit the target
                    Bullets.Remove(b);
                }
            }
