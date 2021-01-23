     for (int i = 0; i < 100; i++)
        {
            //gameSession is int, i tried use Parameters.AddWithValue but still have same problem.
            MySqlCommand dice = new MySqlCommand("INSERT INTO DiceRolls (Session, Dice1,Dice2) Values (@session,@dice1,@dice2)", myConnection);
            dice.Parameters.AddWithValue("@session", gameSession);
            Random dice1 = new Random();
            dice.Parameters.AddWithValue("@dice1", dice1.Next(1, 7));
            Random dice2 = new Random();
            dice.Parameters.AddWithValue("@dice2", dice2.Next(1, 7));
            if (myConnection.State == ConnectionState.Closed)
            {
                myConnection.Open();
            }
            dice.ExecuteNonQuery();
        }
