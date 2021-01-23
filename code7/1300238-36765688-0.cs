    using System.Drawing;
    using System.Windows.Forms;
    public class MyBaseControl : Control
    {
        public MyBaseControl()
        {
            accentColor = Color.Red;
        }
        private Color accentColor;
        public Color AccentColor
        {
            get
            {
                if (accentColor == Color.Red && ParentFormHasAccentColor())
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
            return (Color)this.FindForm().GetType()
                                .GetProperty("AccentColor").GetValue(this.FindForm());
        }
        private bool ShouldSerializeAccentColor()
        {
            if (ParentFormHasAccentColor())
                return this.AccentColor != GetParentFormAccentColor();
            return true;
        }
        private void ResetAccentColor()
        {
            if (ShouldSerializeAccentColor())
                this.AccentColor = GetParentFormAccentColor();
        }
    }
