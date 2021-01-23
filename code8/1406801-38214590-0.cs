    public void RefreshTest()
        {
           if(i==15) 
           { 
                FinishTest(); 
           }
           else
           {
        
                pictureBox1.Image = imageList1.Images[i];
                pictureBox2.Image = imageList2.Images[j];
        
                label1.Text = opt1[i];
                label2.Text = opt2[i];
                label3.Text = opt3[i];
                label4.Text = opt4[i];
                label5.Text = questions[i];
        
            }
        }
