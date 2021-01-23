    using System.Windows.Forms; 
    using MySimpleActivexControlLib;
    
    class Program 
    { 
        [STAThread]
        static void Main() 
        { 
            var c = new MySimpleActivexControlLib.MySimpleActivexControl();
            var form = new Form 
            { 
                Controls = { c } 
            };
    
            form.Load += (s, e) => c.GetSomeString();
    
            Application.Run(form); 
        } 
    }
