           private void Exit()
           {
                DialogResult answer= null;
                answer = MessageBox.Show("Are you sure that you need to quit ?\nAll unsaved data will be lost.","Exit Confirmation!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)
                { 
                    //Do something if the user wants to exit
                }
                else
                {
                    //Do something if user don't want to exit
                }
            }
