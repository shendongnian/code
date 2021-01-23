    public delegate int Test(int s, int j);
    
    var o = new Test_ing();
    
    
    var myDel = new Test(o.ADD);
    myDel += o.Multiply;
    
    var delegates = myDel.GetInvocationList();
    
    var add_result = ((Test)delegates[0])(5, 6);    
    var multiply_result = ((Test)delegates[1])(10, 2);
    
    public class Test_ing
        {
            public int ADD(int i, int j)
            {
                return i + j;
            }
    
            public int Multiply(int i, int j)
            {
                return i * j;
            }
        }
