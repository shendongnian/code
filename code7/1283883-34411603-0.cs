            string str = string.Empty;
            if (e.Key > Key.D0 && e.Key < Key.D9)
            {
                str = ((int)e.Key - (int)Key.D0).ToString();
            }
            MessageBox.Show(str);
