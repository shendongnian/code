    namespace SO_Question_win
{
    //EVERYTHIG under the same namespace might as well be in the sale file as far as C# is concerned. We use different files for convenience. 
    public partial class Form1 : Form
    {
        //this is the form class for the main form in the project. It is where the thread goes when the program starts. No other instance classes will exist until they are created 
        
        public Form1()
        {
            InitializeComponent();
        }
        private void hello()
        {
            //I can only call hello from inside this class.
            My_Other_CS_File other_File = new My_Other_CS_File();
            //you created this instance class here. It will only exist until "hello" finishes running, then it will disappear.
            string hello = "hi";
            //the only way to get the string hello to the class you created is to pass it.
            other_File.SayHello(hello);
            //other_file is done. It will disappear now if you want it again you will have to create a new instance
        }
    }
    public class My_Other_CS_File
    {
        public void SayHello(string hi)
        {
            //here, the string Hi is passed from the form class 
            Console.WriteLine(hi);
            //even though this class was created by the form class, it has access to any public static classes. 
            Console.WriteLine(Global.helloString);
        }
    }
    public static class Global
    {
        //anything marked "public static" here will be visible to any class under the same namespace. This class is niether created nor destroyed - it always exists. hat's the difference bewtween static and instance.
        public static string helloString = "howdy";
    }
