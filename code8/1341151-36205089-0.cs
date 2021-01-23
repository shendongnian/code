    users.Sort((x, y) =>
        {
            DateTime xcd, ycd;
            bool y_ok = DateTime.TryParse(y.createdDate, out ycd);
            bool x_ok = DateTime.TryParse(x.createdDate, out xcd);
            if (!x_ok && !y_ok)
            {
                return 0;
            }
            else if (!x_ok)
            {
                return 1;
            }
            else if (!y_ok)
            {
                return -1;
            }
            return ycd.CompareTo(xcd);
        }
