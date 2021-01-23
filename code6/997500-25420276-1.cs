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
               Player value;
               Point p = new Point(x,y);
               if(_playerLocation.TryGetValue(p, out value))
               {
                    return value ;
               }
               return Player.None; 
          }
          else
            //generate square cache and retry...
       }
    }
