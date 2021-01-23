    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    using System.Text.RegularExpressions;
    using System.IO;
    
    namespace Test
    {
        public partial class MainWindow : Window
        {
            public bool itExists = false;
    
            public MainWindow()
            {
                InitializeComponent();
    
                // Setup PowerShell Environment
                Runspace runSpace = RunspaceFactory.CreateRunspace();
                runSpace.ThreadOptions = PSThreadOptions.UseCurrentThread;
                runSpace.Open();
                PowerShell ps = PowerShell.Create();
                ps.Runspace = runSpace;
                string check = "$itExists = $TRUE";
                ps.AddScript(check);
                // Execute
                ps.Invoke();
    
                var result = runSpace.SessionStateProxy.PSVariable.GetValue("itExists").ToString();
    
                runSpace.Close();
    
                itExists = result.Equals("True");
    
                if (itExists)
                {
                    textBlock.Text = "It is true!";
                }
            }
        }
    }
