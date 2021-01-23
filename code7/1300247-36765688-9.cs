    using System.Drawing;
    using System.Windows.Forms;
    public class MyBaseControl : Control
    {
        public MyBaseControl()
        {
            accentColor = Color.Empty;
        }
        private Color accentColor;
        public Color AccentColor
        {
            get
            {
                if (accentColor == Color.Empty && ParentFormHasAccentColor())
                    return GetParentFormAccentColor();
                return accentColor;
            }
            set
            {
                if (accentColor != value)
                    accentColor = value;
            }
        }
        private bool ParentFormHasAccentColor()
        {
            return this.FindForm() != null &&
                   this.FindForm().GetType().GetProperty("AccentColor") != null;
        }
        private Color GetParentFormAccentColor()
        {
            if (ParentFormHasAccentColor())
                return (Color)this.FindForm().GetType()
                                   .GetProperty("AccentColor").GetValue(this.FindForm());
            else
                return Color.Red;
        }
        private bool ShouldSerializeAccentColor()
        {
            return this.AccentColor != GetParentFormAccentColor();
        }
        private void ResetAccentColor()
        {
            this.AccentColor = GetParentFormAccentColor();
        }
    }
