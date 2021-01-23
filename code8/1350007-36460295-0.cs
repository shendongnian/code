    private void btnSum_Click(object sender, RoutedEventArgs e)
    {
    String num1 = txtNum1.Text;
    String num2 = txtNum2.Text;    
    if(validate(num1,num2) == false)
    {
        MessageBox.Show("Empty fields");
    }
    else 
    {
      var result  =  convertNum(num1, num2);    
       MessageBox.Show("The sum is: "+result);   
    }
    }
    public static int convertNum(String n1,String n2) 
    {
    int num1 = 0;
    int num2 = 0;
    try 
    {
        num1 = Int32.Parse(n1);
        num2 = Int32.Parse(n2);  
      int result = sum(num1,num2); 
      return result;    
    }
    catch(FormatException)
    {
        MessageBox.Show("Input only numbers.");   
    }                
    }
    public static int sum(int n1, int n2) 
    {
    int sum = n1 + n2;
    return sum;    
    }
