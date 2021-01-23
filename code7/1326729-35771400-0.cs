    bool pBDoIntersect;
    
     foreach (Control picturebox in this.Controls)
            {
                if (PB.Bounds.IntersectsWith(picturebox.Bounds))
                {
                    pBDoIntersect=true;
                }
            }
    
    if(!pBDoIntersect)this.Controls.Add(PB);
