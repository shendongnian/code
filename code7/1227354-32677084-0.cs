            string s = "$123.78";
            float f;
            if (float.TryParse(s, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out f))
            {
                // OK
            }
            else
            {
                // WRONG
            }
