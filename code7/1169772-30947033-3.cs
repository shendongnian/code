    public class BlueBall : Obj
    {
        private int score;
    
        public void CheckCollisions()
        {
            if (collision)
               score += 20;
        }
    }
