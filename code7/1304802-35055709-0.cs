    public class MarathiHelper
    {
        private static Dictionary<char, char> arabicToMarathi = new Dictionary<char, char>()
        {
          {'1','१'},
          {'2','२'},
          {'3','३'},
          {'4','४'},
          {'5','५'},
          {'6','६'},
          {'7','७'},
          {'8','८'},
          {'9','९'},
          {'0','०'},
        };
        public static string ReplaceNumbers(string input)
        {
            foreach (var num in arabicToMarathi)
            {
                input = input.Replace(num.Key, num.Value);
            }
            return input;
        }
    }
