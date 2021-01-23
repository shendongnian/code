	 private static readonly Random random = new Random();
     private static readonly object syncLock = new object();
     public static int RandomNumber(int min, int max)
     {
         lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
     }
     private void button2_Click(object sender, EventArgs e)
     {
         button2.Text = RandomNumber(5, 10).ToString();
     }
