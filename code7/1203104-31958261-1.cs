    public static string ToHtmlColorValue(this string rgb) // rgb parameter
            {
                string result = "000000";
                try
                {
                    string[] parts = rgb.Split(',');
                    int r = int.Parse(parts[0]);
                    int g = int.Parse(parts[1]);
                    int b = int.Parse(parts[2]);
                    result = r.ToString("x2") + g.ToString("x2") + b.ToString("x2");
                }
                catch
                {
                    // do nothing
                }
                return result;
            }
