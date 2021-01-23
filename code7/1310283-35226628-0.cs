    public string GetColorName(Brush brush)
            {
                string name = "Unknown";
                Color c = new Pen(brush).Color;
    
                foreach (KnownColor kc in Enum.GetValues(typeof(KnownColor)))
                {
                    Color known = Color.FromKnownColor(kc);
                    if (c.ToArgb() == known.ToArgb())
                    {
                        name = known.Name;
                        break;
                    }
                }
    
                return name;
            }
