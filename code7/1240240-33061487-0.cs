    public partial class Form2 : Form
    {
    
        List<string> username = new List<string>{ "test", "aaa" };
        List<string> password = new List<string>{ "password", "123" };
    
    	private void btnSubmit_Click(object sender, EventArgs e)
        {
    		try
    		{
    			if (txtUsername.Text.Length > 0 && txtPassword.Text.Length > 0 
    				&& username.FirstOrDefault(x => x == txtUsername.Text.Trim()) != null
    				&& password.FirstOrDefault(x => x == txtPassword.Text.Trim()) != null)
    		    	{
    					MessageBox.Show(
                            "Login Successful. Welcome!", 
                            "Login Success", MessageBoxButtons.OK, MessageBoxIcon.None);
    					Form3 frm3 = new Form3();
    					frm3.Visible = true;
    					frm3.Activate();
    				}
    				else
    				{
    					MessageBox.Show(
                            "You have entered an invalid input. Do you want to try again?", 
                             "Invalid Input", 
                             MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
    				}
    			}
    			catch(Exception x)
    			{
    				MessageBox.Show(
                        "System Error! Please try again!", 
                        "System Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
    			}
    		}
    	}
    }
