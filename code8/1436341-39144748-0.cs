    //------------------------------------------------------------------------------
    // <copyright file="Command1.cs" company="Company">
    //     Copyright (c) Company.  All rights reserved.
    // </copyright>
    //------------------------------------------------------------------------------
    
    using System;
    using System.ComponentModel.Design;
    using System.Globalization;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using EnvDTE;
    using EnvDTE80;
    
    namespace SolExpExt
    {
        internal sealed class Command1
        {
            public const int CommandId = 0x0100;
            public static readonly Guid CommandSet = new Guid("beff5a1a-dff5-4f6a-95c8-fd7ea7411a7b");
            private DTE2 dte;
            private readonly Package package;
            private IVsSolution sol;
            private Command1(Package package)
            {
                if (package == null)
                {
                    throw new ArgumentNullException("package");
                }
    
                this.package = package;
    
                OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
                if (commandService != null)
                {
                    var menuCommandID = new CommandID(CommandSet, CommandId);
                    var menuItem = new MenuCommand(this.MenuItemCallback, menuCommandID);
                    commandService.AddCommand(menuItem);
                }
    
                dte = this.ServiceProvider.GetService(typeof(EnvDTE.DTE)) as EnvDTE80.DTE2;
            }
    
            public static Command1 Instance
            {
                get;
                private set;
            }
    
            private IServiceProvider ServiceProvider
            {
                get
                {
                    return this.package;
                }
            }
    
            public static void Initialize(Package package)
            {
                Instance = new Command1(package);
            }
    
            private void MenuItemCallback(object sender, EventArgs e)
            {
                string message = $"There are {dte.Solution.Projects.Count} projects in this solution.";
                string title = "Command1";
    
                VsShellUtilities.ShowMessageBox(
                    this.ServiceProvider,
                    message,
                    title,
                    OLEMSGICON.OLEMSGICON_INFO,
                    OLEMSGBUTTON.OLEMSGBUTTON_OK,
                    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
            }
        }
    }
