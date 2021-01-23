    public static class GodObject {
        public static bool IsEmail(string email) {
            //declare the return variable 
            bool rst = false;
    
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            // does the string follow the regex structure?
            System.Text.RegularExpressions.Match match = regex.Match(email);
            //if yes
            if (match.Success){
                rst = true;
            } else {
                rst = false;   
            }
    
            return rst; 
        }
    }
