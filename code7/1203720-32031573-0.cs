    int id = map.Layers[1].Tiles[i].Gid;
                if (id == 172)
                {
                    enemys.Add(new Hero.World.Entitys.Enemys.Octorock(new Vector2((int)position.X + map.Layers[1].Tiles[i].X * 16, (int)position.Y + map.Layers[1].Tiles[i].Y * 16),i));
                }
