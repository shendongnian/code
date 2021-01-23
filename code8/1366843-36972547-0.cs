            // Colours
            System.Drawing.Color accent = new System.Drawing.Color();
            System.Drawing.Color fore = new System.Drawing.Color();
            System.Drawing.Color back = new System.Drawing.Color();
            try
            {
                accent = ColorFromString(result.Color.AccentColor.ToString());
                fore = ColorFromString(result.Color.DominantColorForeground.ToString());
                back = ColorFromString(result.Color.DominantColorBackground.ToString());
                displayData.Colors = new System.Drawing.Color[] { accent, fore, back };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
...
        private System.Drawing.Color ColorFromString(string color)
        {
            System.Drawing.Color value = new System.Drawing.Color();
            // Hex Color Format
            Regex hex = new Regex("^#(?:[0-9a-fA-F]{3}){1,2}$");
            try
            {
                if (hex.IsMatch("#" + color)) value = ColorTranslator.FromHtml("#" + color);
                else value = ColorTranslator.FromHtml(color);
            }
            catch (Exception)
            {
                ColorFix colorFix = new ColorFix(color);
                value = colorFix.Fix();
            }
            return value;
        }
