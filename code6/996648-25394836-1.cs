    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Windows.Forms;
    namespace ConsoleApplication59
    {
        class Program
        {
            static void Main(string[] args)
            {
                Thread FormThread = new Thread(FormCall);
                FormThread.Start();
                Thread.Sleep(2000); //Sleep to allow form to be created
                Thread setLightThread = new Thread(setLightCall);
                setLightThread.Start(Application.OpenForms[0]); //We can get by with this because just one form
                Console.ReadLine();
            }
            
            public static void setLightCall(object parent)
            {
                Form1 updateForm = (Form1)parent;
                while (true)
                {
                   updateForm.Invoke(updateForm.setLights, new object[] { false });
                }
            }
            public static void FormCall()
            {
                Application.Run(new Form1());
   
            }
        }
    }
