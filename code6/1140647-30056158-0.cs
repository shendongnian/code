    using System.Collections.Generic;
    
    class EnemyTeam
    {
    
        private List<Ellipse> enemies = new List<Ellipse>();
        private Canvas canvas;
        private double xChange = 50, yChange = 50;
        public DispatcherTimer enemyTimer;
        private char direction = '0';
        private Thickness enemyThickness;
    
        public EnemyTeam(Canvas canvas, double startPosition, SolidColorBrush playerBrush)
        {
            this.canvas = canvas;
            DrawTeam(canvas, 40, playerBrush);
            enemyTimer = new DispatcherTimer();
            enemyTimer.Interval = TimeSpan.FromMilliseconds(100);
    		enemyTimer.Tick += enemyTimer_Tick;
            enemyTimer.Start();
        }
    
        private void DrawBall(SolidColorBrush brush, Canvas canvas,double x,double y)
        {
            enemy = new Ellipse();
            enemy.Stroke = brush;
            enemy.Fill = brush;
            enemy.Height = 30;
            enemy.Width = 30;
            enemy.Margin = new Thickness(x,y, 0, 0);
            enemyThickness = enemy.Margin; // what is this supposed to do?
            canvas.Children.Add(enemy);
    		enemies.Add(enemy);
        }
    
        void enemyTimer_Tick(object sender, EventArgs e)
        {
    	    foreach (Ellipse enemy in enemies)
    		{
    			if (enemyThickness.Left >= canvas.Width - 100)
    			{
    				GoDown();
    				direction = '1';
    			}
    
    			if (enemyThickness.Left <= 0 + 20)
    			{
    				GoDown();
    				direction = '0';
    			}
    			MoveTeam(enemy);
    		}
        }
    
        private void MoveTeam(Ellipse enemy)
        {
            enemyThickness = enemy.Margin;
    
            if (direction == '1')
            {
                enemyThickness.Left -= xChange;
            }
    
            if (direction == '0')
            {
                enemyThickness.Left += xChange;
            }
    
            enemy.Margin = enemyThickness;
        }
    
        private void GoDown()
        {
            enemyThickness.Top += yChange;
            enemy.Margin = enemyThickness;
        }
    }
