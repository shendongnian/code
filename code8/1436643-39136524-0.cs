    public static testClass PrettyDo(MyTask task)
    {
        Check(task);
        //...
        testClass answer = new testClass();
    
        answer.param1 = 7;
        answer.param2 = "Done.";
    
        return answer;
    }
    
    public class testClass
    {
        public int param1 { get; set; }
        public string param2 { get; set; }
    }
