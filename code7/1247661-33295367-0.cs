    public class MyClass
    {
        public class CustomColor
        {
            public int h;
            public int s;
            public int v;
        }
        public enum Convert { H, S, V, HS, HV, SV, HSV };
        public void ConvertColors(ref List<CustomColor> colors, Convert type,
            ref CustomColor changeAmt)
        {
            // Variables to change H, S, and V from changeAmt parameter:
            int changeH = changeAmt.h;
            int changeS = changeAmt.s;
            int changeV = changeAmt.v;
            // Change the actual colors which were passed as 'colors' parameter.
            switch (type)
            {
                // Change H.
                case Convert.H:
                    foreach (CustomColor c in colors)
                        c.h += changeH;
                    break;
                // Change S.
                case Convert.S:
                    foreach (CustomColor c in colors)
                        c.s += changeS;
                    break;
                // Change V.
                case Convert.V:
                    foreach (CustomColor c in colors)
                        c.v += changeV;
                    break;
                // Change HS.
                case Convert.HS:
                    foreach (CustomColor c in colors)
                    {
                        c.h += changeH;
                        c.s += changeS;
                    }
                    break;
                // Change HV.
                case Convert.HV:
                    foreach (CustomColor c in colors)
                    {
                        c.h += changeH;
                        c.v += changeV;
                    }
                    break;
                // Change SV.
                case Convert.SV:
                    foreach (CustomColor c in colors)
                    {
                        c.s += changeS;
                        c.v += changeV;
                    }
                    break;
                // Change HSV.
                case Convert.HSV:
                    foreach (CustomColor c in colors)
                    {
                        c.h += changeH;
                        c.s += changeS;
                        c.v += changeV;
                    }
                    break;
            }
        }
    }
