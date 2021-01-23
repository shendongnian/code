        public SolidColorBrush Color
        {
            get
            {
                return this.color;
            }
            set
            {
                if (color != null && value != null)
                {
                    if (color.Color.Equals(value.Color))
                        return;
                }
                else if (color == null && value == null)
                    return;
                this.color = value;
            }
        }
