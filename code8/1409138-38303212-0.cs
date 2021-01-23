    public class Program1     
    {
        public void method1(string[] args){ 
            //some code here, , with  a lot of "Console.Writeline"
        }
    }
--------------
    private void button1_Click(object sender, EventArgs e){
        Program1 program = new Program1();
        program.method1(new string[]{"one","two"});
    }
