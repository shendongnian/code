                SqlParameter pass = new SqlParameter();
                pass.ParameterName = "@password";
                //pass.Value = Hasher.HashString(password.Trim());
                pass.Value = password.Trim(); 
                cmd.Parameters.Add(pass);
