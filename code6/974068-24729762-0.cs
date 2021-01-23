    using System.Windows.Forms; 
    using MySimpleActivexControlLib;
    
    class Program 
    { 
        [STAThread]
        static void Main() 
        { 
            var form = new Form 
            { 
                Controls = { new MySimpleActivexControlLib.MySimpleActivexControl(); } 
            };
    
            form.Load += (s, e) => c.GetSomeString();
    
            Application.Run(form); 
        } 
    }
