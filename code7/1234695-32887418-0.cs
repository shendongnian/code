    using System;
    
    namespace sam_StreamReader
    {
        class Program
        {
            static void Main(string[] args)
            {
                login("user1", "abc");
                login("user2", "xxx");
                login("user2", "Password2");
                login("user1", "Password1");
            }
            static bool login(string p_user_name,string p_password)
            {
                String[] Username = { "user1", "user2", "user3" };
                String[] Password = { "Password1", "Password2", "Password3" };
                for(int i=0;i<Username.Length;i++)
                {
                    if(p_user_name == Username[i])
                    {
                        if(p_password == Password[i])
                        {
                            System.Console.WriteLine("User "+p_user_name+" login success!!");
                            return true;
                        }
                    }
                }
                System.Console.WriteLine("User=" + p_user_name + ", Password="+p_password+" login failed!!");
                return false;
            }
    
        }
    }
