    List<Int64> selectedUsers = GetSelectedUsers();
    			
    			if (MessageBox.Show(this, ((Func<string, string>)(message =>
    			{
    				message = "Are you sure you want to delete user(s) ID";
    				foreach (Int64 id in selectedUsers)
    				{
    					message += " " + id.ToString();
    				}
    				message += "?";
    				return message;
    			}))(""), "Confirmation Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
    			{
    				//DoSomething();
    			}
    		}
