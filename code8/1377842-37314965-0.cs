    private void Submit()
        {
            if (CheckBox1.Checked == true)
            {
                try
                {
                   //some stuff
                }
                catch
                {
                   //Some other stuff
                }
    
            }
            if (CheckBox1.Checked == false)
            {
                    string script2 = "alert(\"Please Agree to our terms.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript", script2, true);
            }
        }
