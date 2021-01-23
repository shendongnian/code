    class CustomTextBox  : TextBox
    {      
       protected override void OnClick(EventArgs e)
       {          
           //place your code here if you want to do the processing before the contol raises the event. Before call to  base.OnClick(e);
           base.OnClick(e); // call to base funciton fires event 
           //place your code here if you want to do the processing after the contol raises the event. After call to  base.OnClick(e);
       }
    }
