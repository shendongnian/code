    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using Microsoft.Win32;
    
    
    public void GetInstalledApps()  
    {  
       string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";  
       using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))  
       {  
           foreach (string skName in rk.GetSubKeyNames())  
           {  
               using (RegistryKey sk = rk.OpenSubKey(skName))  
               {  
                   try  
                   {    
                      listBox1.Items.Add(sk.GetValue("DisplayName"));                             
                   }  
                   catch (Exception ex)  
                   { }  
               }  
           }  
           label1.Text = listBox1.Items.Count.ToString();  
       }  
    }   
