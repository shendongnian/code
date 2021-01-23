        private void timer1_Tick(object sender, EventArgs e)
            if (command.ExecuteNonQuery == 0)
        {
            Console.WriteLine("0-removed")
        }
    else
        {
            Console.WriteLine("not deleted")
