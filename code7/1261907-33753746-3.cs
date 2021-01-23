        foreach (var control in this.Controls)
        {
            if (control is TextBox)
            {
                if (t.Name != null && t.Name == iy.ToString())
                {
                    this.Controls.Remove(t);
                    t.Dispose();
                    break;
                }
            }
        }
