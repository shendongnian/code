    public class PlayerLocaiton
    {
        Dictionary<Point, List<Player>> _playerLocation = new ...
        public void SetPlayer(int x, int y, Player p)
        {
          _playerLocation[new Point(x,y)].add(p); 
        }
    
        public Player GetSquareCache(int x, int y)
        {
          if (squaresCacheValid)
          {
               if (_playerLocation.ContainsKey[new Point(x,y)])
               {
                    return playerLocation[new Point(x,y)];
               }
               else
               {
                    return Player.None;
               } 
          }
          else
            //generate square cache and retry...
       }
    }
