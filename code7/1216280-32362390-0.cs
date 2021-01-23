    private void btnSubmitTest_Click(object sender, EventArgs e)
                {
                    Random rdm = new Random();
                    int testScore = rdm.Next(0, 100);
                    string score = testScore.ToString();
        
        
                    string name = txtName.Text;
        
                    //Generate a new test that passes in 
                    Test tests = new Test(name, score);
        
                    label3.Text = String.Format("{0} {1}", name, score);
                }
