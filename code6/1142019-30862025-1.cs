     Color currentBlink;     
     private void blinkLabels(Label label)
     {
                label.ForeColor = currentBlink;        
     }
    
     void timer_Tick(object sender, System.EventArgs e)
        {
            if (currentBlink== Color.White)
                currentBlink = blinkingColor;
            else
                currentBlink = Color.White;
    
            
            if(flag1 == true)
                blinkLabels(label1);
            if(flag2 == true)
                blinkLabels(label2);
        }
