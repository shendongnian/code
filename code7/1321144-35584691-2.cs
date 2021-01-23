    private void Auto_play()
    {
        try
        {
            bool foundMove = false;
            while (!foundMove)
            {
                foundMove = true;
                Random rnd = new Random();
                int d = rnd.Next(0, 9);
                label3.Text = d.ToString();
                if (d == 0 && A1.Enabled)
                    A1.PerformClick();
                else if (d == 1 && A2.Enabled)
                    A2.PerformClick();
                else if (d == 2 && A3.Enabled)
                    A3.PerformClick();
                else if (d == 3 && B1.Enabled)
                    B1.PerformClick();
                else if (d == 4 && B2.Enabled)
                    B2.PerformClick();
                else if (d == 5 && B3.Enabled)
                    B3.PerformClick();
                else if (d == 6 && C1.Enabled)
                    C1.PerformClick();
                else if (d == 7 && C2.Enabled)
                    C2.PerformClick();
                else if (d == 8 && C3.Enabled)
                    C3.PerformClick();
                else
                    foundMove = false;
            }
        }
        catch { }
    }
