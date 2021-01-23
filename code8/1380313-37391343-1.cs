    public class FontColor
        {
            public string Name { get; set; }
            public SolidColorBrush Brush { get; set; }
    
            public FontColor(string name, SolidColorBrush brush)
            {
                Name = name;
                Brush = brush;
            }
    
            public override bool Equals(System.Object obj)
            {
                if (obj == null)
                {
                    return false;
                }
    
                FontColor p = obj as FontColor;
                if ((System.Object)p == null)
                {
                    return false;
                }
    
                return (this.Name == p.Name) && (this.Brush.Equals(p.Brush));
            }
    
            public bool Equals(FontColor p)
            {
                if ((object)p == null)
                {
                    return false;
                }
    
                return (this.Name == p.Name) && (this.Brush.Equals(p.Brush));
            }
    
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
    
            public override string ToString()
            {
                return "FontColor [Color=" + this.Name + ", " + this.Brush.ToString() + "]";
            }
        }
    }
    class AvailableColors : List<FontColor>
        {
            #region Conversion Utils Static Methods
            public static FontColor GetFontColor(SolidColorBrush b)
            {
                AvailableColors brushList = new AvailableColors();
                return brushList.GetFontColorByBrush(b);
            }
    
            public static FontColor GetFontColor(string name)
            {
                AvailableColors brushList = new AvailableColors();
                return brushList.GetFontColorByName(name);
            }
    
            public static FontColor GetFontColor(Color c)
            {
                return AvailableColors.GetFontColor(new SolidColorBrush(c));
            }
    
            public static int GetFontColorIndex(FontColor c)
            {
                AvailableColors brushList = new AvailableColors();
                int idx = 0;
                SolidColorBrush colorBrush = c.Brush;
    
                foreach (FontColor brush in brushList)
                {
                    if (brush.Brush.Color.Equals(colorBrush.Color))
                    {
                        break;
                    }
    
                    idx++;
                }
    
                return idx;
            }
            #endregion
    
            public AvailableColors()
                : base()
            {
                this.Init();
            }
    
            public FontColor GetFontColorByName(string name)
            {
                FontColor found = null;
                foreach (FontColor b in this)
                {
                    if (b.Name == name)
                    {
                        found = b;
                        break;
                    }
                }
                return found;
            }
    
            public FontColor GetFontColorByBrush(SolidColorBrush b)
            {
                FontColor found = null;
                foreach (FontColor brush in this)
                {
                    if (brush.Brush.Color.Equals(b.Color))
                    {
                        found = brush;
                        break;
                    }
                }
                return found;
            }
    
            private void Init()
            {
                Type brushesType = typeof(Colors);
                var properties = brushesType.GetProperties(BindingFlags.Static | BindingFlags.Public);
    
                foreach (var prop in properties)
                {
                    string name = prop.Name;
                    SolidColorBrush brush = new SolidColorBrush((Color)(prop.GetValue(null, null)));
                    this.Add(new FontColor(name, brush));
                }
    
            }
        }
