    using EnvDTE;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    
    namespace Test
    {
        public partial class Form1 : Form
        {
            public class DTEHandle
            {
                //EnvDTE.Project proj;
                //EnvDTE.Configuration config;
                //EnvDTE.Properties configProps;
                //EnvDTE.Property prop;
                EnvDTE.DTE DTE = Marshal.GetActiveObject("VisualStudio.DTE.14.0") as EnvDTE.DTE;
                public EnvDTE.Project GetProject(String Name)
                {
                    foreach (EnvDTE.Project item in DTE.Solution.Projects)
                    {
                        if (item.Name == Name)
                        {
                            return item;
                        }
                    }
                    return null;
                }
            }
    
            public Form1()
            {
                InitializeComponent();
                EnvDTE.DTE DTE = Marshal.GetActiveObject("VisualStudio.DTE.14.0") as EnvDTE.DTE;
    
                DTEHandle h = new DTEHandle();
                EnvDTE.Project proj = h.GetProject("Test");
       
                foreach (EnvDTE.ProjectItem item in proj.ProjectItems)
                {
                    if (item.Name == "Program.cs")
                    {
                        TextSelection s = item.Document.Selection as TextSelection;
                        s.SelectAll();
                        MessageBox.Show(s.Text);
                    }
                }          
            }
        }
    }
