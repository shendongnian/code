    private void timer2_Tick(object sender, EventArgs e)
        {
    
            while (block.Left > (ClientSize.Width-ClientSize.Width))
            {
                Thread.Sleep(50); //how about putting sleep here for 50ms?
                block.Left -= 1;
                if (block.Left == (ClientSize.Width - ClientSize.Width))
                {
                    break;
                }
    
            }
            while (block.Right < ClientSize.Width)
            {
                Thread.Sleep(50); //how about putting sleep here for 50ms?
                block.Left += 1;
                if (block.Right == ClientSize.Width)
                {
                    break;
                }  
            }   
        }
