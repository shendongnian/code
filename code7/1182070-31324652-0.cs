    struct ColorCode
    {
        int hex;
        public static readonly ColorCode
            AliceBlue = 0xF0F8FF,
            AntiqueWhite = 0xFAEBD7;
        // and the rest of the ColorCodes
        public static implicit operator Color(ColorCode cc)
        {
            return /* cc converted to a Color */;
        }
        public static implicit operator ColorCode(int cc)
        {
            return new ColorCode() { hex = cc };
        }
    }
