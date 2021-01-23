    namespace TestConsole
    {
        using System.Collections.Generic;
        using System.Runtime.InteropServices;
        using System;
        using System.Text;
    
     
        public class CountWindows
        {
            
            public delegate bool EnumDelegate(IntPtr hWnd, int lParam);
    
          
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool IsWindowVisible(IntPtr hWnd);
    
     
            [DllImport("user32.dll", EntryPoint = "GetWindowText",
            ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
            public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpWindowText, int nMaxCount);
    
           
            [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows",
            ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumDelegate lpEnumCallbackFunction, IntPtr lParam);
    
         
            static void Main()
            {
                var collection = new List<string>();
                CountWindows.EnumDelegate filter = delegate (IntPtr hWnd, int lParam)
                {
                    StringBuilder strbTitle = new StringBuilder(255);
                    int nLength = CountWindows.GetWindowText(hWnd, strbTitle, strbTitle.Capacity + 1);
                    string strTitle = strbTitle.ToString();
    
                    if (CountWindows.IsWindowVisible(hWnd) && string.IsNullOrEmpty(strTitle) == false)
                    {
                        collection.Add(strTitle);
                    }
                    return true;
                };
    
                if (CountWindows.EnumDesktopWindows(IntPtr.Zero, filter, IntPtr.Zero))
                {
                    foreach (var item in collection)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Count : "+ collection.Count);
                }
                Console.Read();
            }
        }
    
    
    }
