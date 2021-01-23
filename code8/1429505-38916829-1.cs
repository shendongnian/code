        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string duration = dt.Rows[i][1].ToString();
            if (duration == "")
            {
                dt.Rows[i].Delete();
                continue;                //Not printing deleted objects. So line after IF block won'nt exist.
            }
            Console.WriteLine(i.ToString() + dt.Rows[i][1].ToString());
        }
