    namespace test
    {
        public delegate void callback(String msg);
    
    
        public partial class Form1 : Form
        {
            public static ListBox callbackListBox;       //  add this
            
            public void writeToListbox(String s)
            {
                if(null == callbackListBox)return;       // add this check
                
                // also make this threadsafe:
                if (callbackListBox.InvokeRequired)
                {
                    callbackListBox.Invoke(new MethodInvoker(() => { writeToListbox(s); }));
                }else{
                    callbackListBox.Items.Add(s);
                    callbackListBox.TopIndex = callbackListBox.Items.Count - (callbackListBox.Height / callbackListBox.ItemHeight);
                }
            }
            
            public static void writeToConsole(String s)
            {
                System.Console.WriteLine(s);
            }
            public void createclass
            {
                callback ui_update = writeToListbox;     // now OK
                someclass SC = new someclass(ui_update);
            }
            
            // and add this to the form's constructor:
            public Form1()
            {
                InitializeComponent();
                callbackListBox = listbox1;
            }
    
        }
    
        class someclass
        {
            callback cb;
            void someclass(callback T)
            {
                this.cb = T;
            }       
            void logthis(string s)
            {
                cb("it's me!");
            }
        }
    }
    
