    public class Login 
    {
        string varUserName;
        string varUserPass;
        // Dictionary object is c# equivalent of PHP's 'array["key"] = "value"'
        Dictionary<string, string> errMsg = new Dictionary<string, string>();
        public Dictionary<string, string> LogMeIn()
        {
            varUserName = "123qwe";
            varUserName = varUserName.Trim();
            if ((varUserPass == "") && (varUserName == ""))
            {
                errMsg.Add("Username", "Username cannot be blank");
                errMsg.Add("Password", "Username cannot be blank");
            }
            else
            {
                if (varUserName == "")
                {
                    errMsg.Add("Username", "Username cannot be blank");
                }
                if (varUserPass == "")
                {
                    errMsg.Add("Password", "Password cannot be blank");
                }
            }
        return errMsg;
        }    
    
    }
