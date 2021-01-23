       public void Beep()
        {
            if (MessageBox.Show("Message", "Alert", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
            {
                    Console.Beep(5000, 5000);
                    Beep();
            }
        }
