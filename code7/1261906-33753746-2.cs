     foreach (TextBox t in this.Controls)
     {
           if (t.Name == iy.ToString())
           {
                this.Controls.Remove(t);
                t.Dispose();
                break;
           }
     }
