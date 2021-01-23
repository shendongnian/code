    var topSecret = "This is%&/(/ TopSecret 111!!";
                int shft = 5;
                string encrypted = "";
                string decrypted = "";
                foreach (var ch in topSecret)
                {
                    var val = ((int) ch) << shft;
                    encrypted += (char)(val*2);
                }
                encrypted = Convert.ToBase64String(Encoding.UTF8.GetBytes(encrypted));
    
    
                foreach (var ch in Encoding.UTF8.GetString(Convert.FromBase64String(encrypted)))
                {
                    var val = ((int) ch) >> shft;
                    decrypted += (char) (val / 2);
                }
