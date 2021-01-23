    public class ColorItem
    {
        override bool Equals(object other) {
            ColorItem c = other as ColorItem;
            return c.Red == this.Red && c.Blue = this.Blue && c.Green == this.Green;
        }
    }
