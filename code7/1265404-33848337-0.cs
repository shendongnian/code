        SQLiteConnection conn = new SQLiteConnection();
        SQLiteCommand cmd;
        SQLiteTransaction transaction;
        private void runCommand()
        {
            using (conn = new SQLiteConnection(""))
            {
                using (transaction = conn.BeginTransaction())
                {
                    //Do your work here
                    cmd.CommandText = "SELECT * FROM TABLE...";
                    transaction.Commit();
                }
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            cmd.Cancel();
            //OR
            transaction.Rollback();
        }
