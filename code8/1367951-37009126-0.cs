    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using vbForm = Microsoft.Vbe.Interop.Forms;
    using office = Microsoft.Office.Core;
    
    //[assembly: Guid("B5C4D7F5-C9B2-491e-91BA-63C208959190")]
    
    namespace COM_ClassLib_CS
    {
    
        [Guid("BF78EB64-F59B-4086-9FC5-B87AA2002F4F")]
        [ComVisible(true)]
        public interface IVBAExtensions
        {
            string getTest(object app);
            void formData(object formControl);
            void passWordDoc(object doc);
            object[,] returnArray();
            string returnString();
        }
    
        [Guid("EC0B623E-E8A0-4564-84FB-2D8D149C8BA7")]
        [ClassInterface(ClassInterfaceType.None)]
        [ComVisible(true)]
        public class VBAExtensions : IVBAExtensions
        {
            public VBAExtensions()
            {
            }
            //test using late-binding
            public string getTest(object app)
            {
                object xlApp = app.GetType().InvokeMember("Application", System.Reflection.BindingFlags.GetProperty, null,
                    app, null);
                object nm = xlApp.GetType().InvokeMember("Name", System.Reflection.BindingFlags.GetProperty, null,
                    xlApp, null);
                string appName = nm.ToString();
                object isReady = xlApp.GetType().InvokeMember("Ready", System.Reflection.BindingFlags.GetProperty, null,
                    xlApp, null);
                string sReady = isReady.ToString();
                return sReady;
            }
            //test calling from a UserForm, passing control as argument
            public void formData(object formControl)
            {
                //string data = "";
                vbForm.TextBox t = formControl as vbForm.TextBox;
                t.Text = "test";
                //return data;
            }
            //test passing doc object and accessing its Window
            public void passWordDoc(object doc)
            {
                Microsoft.Office.Interop.Word.Document WordDoc = doc as Microsoft.Office.Interop.Word.Document;
                WordDoc.ActiveWindow.Caption = "Tested!";
            }
            //test returning an array to VBA calling procedure
            public object[,] returnArray()
            {
                
                //object[] array = new object[2] {"a", "b"};
                object[,] array = new object[2, 2];
                array[0, 0] = "a";
                array[0, 1] = "1";
                array[1, 0] = "b";
                array[1, 1] = "2";
                return array;
            }
    
            //test returning a string to VBA calling procedure
            public string returnString()
            {
                return "AbC";
            }
                
        }
    }
