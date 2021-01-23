    Please try the following code. Up and running on VS2015.
    
    `
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
            public Form1()
            {
                InitializeComponent();
                EnvDTE.Project proj;
                EnvDTE.Configuration config;
                EnvDTE.Properties configProps;
                EnvDTE.Property prop;
                var DTE = Marshal.GetActiveObject("VisualStudio.DTE.14.0") as EnvDTE.DTE;
                if (DTE == null) throw new Exception("Error al obtener la referencia a DTE.");
                proj = DTE.Solution.Projects.Item(1);
                config = proj.ConfigurationManager.ActiveConfiguration;
                configProps = config.Properties;
                prop = configProps.Item("EnableSQLServerDebugging");
                MessageBox.Show(proj.ToString());
            }
        }
    }
    `
