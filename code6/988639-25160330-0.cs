        public bool isVisible(Control c)
        {
            if (c.Visible == false)
                return false;
            else
                if (c.Parent != null)
                    return isVisible(c);
                else
                    return c.Visible;
        }
