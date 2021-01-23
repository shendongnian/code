       public class CleanAccent
    {
        public static string RemoveDiacritics(string input)
        {
            // Indicates that a Unicode string is normalized using full canonical decomposition.
            if (String.IsNullOrEmpty(input)) return input;
            string inputInFormD = input.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            for (int idx = 0; idx < inputInFormD.Length; idx++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(inputInFormD[idx]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(inputInFormD[idx]);
                }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }
    }
