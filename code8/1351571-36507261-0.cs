        public class Hex
        {
            public Point Location;
            public Country Holder;
    
            public Hex(Country holder = null)
            {
                Holder = holder;
            }
    
            public void DrawMe(Graphics g)
            {
                g.DrawImage(Middle_Ages_Country.Properties.Resources.h, new Rectangle(Location, new Size(40, 40)));
            }
        }
