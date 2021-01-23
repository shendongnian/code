    using System;
    using System.Linq;
    using IO = System.IO;
    using System.Windows.Forms;
    using WixSharp;
    using WixSharp.Forms;
    using Microsoft.Win32;
    using Microsoft.Deployment.WindowsInstaller;
    using System.Diagnostics;
    namespace WixSharpSetup
    {
        class Program
        {
    #if DEBUG
            const string BUILD = "Debug";
    #else
            const string BUILD = "Release";
    #endif
            static void Main()
            {
                var binariesFeature = new Feature("Feature 1", "Feature 1");
                var extensionFeature = new Feature("Feature 2", "Feature 2");
                var project = new ManagedProject("My Company Test Product",
                    //new ManagedAction(CustomActions.SetInstallPaths, Return.ignore, When.Before, Step.InstallInitialize, Condition.NOT_Installed),
                    new Dir(new Id("MAIN_INSTALL_PATH"), binariesFeature, @"%ProgramFiles%\My Company\Test Product",
                        new File(new Id("FEATURE1_FILE1"), binariesFeature, @"..\ClassFoo\bin\" + BUILD + @"\ClassFoo.dll"))
    /* **** THIS DIRECTORY NEEDS TO BE SET PROGRAMATICALLY TO THE FEATURE1_INSTALL_PATH *****/
                    , new Dir(new Id("FEATURE1_INSTALL_PATH"), binariesFeature, "NOT_SET",
                        new File(new Id("FEATURE1_FILE2"), binariesFeature, @"..\ClassFoo\bin\" + BUILD + @"\test extra file.txt"))
    /* **** THIS DIRECTORY NEEDS TO BE SET PROGRAMATICALLY TO THE FEATURE2_INSTALL_PATH *****/
                    , new Dir(new Id("FEATURE2_INSTALL_PATH"), extensionFeature, @"NOT_SET",
                        new File(new Id("FEATURE2_FILE"), extensionFeature, @"..\ClassFoo\bin\" + BUILD + @"\ClassFoo.dll"))
                    );
                project.DefaultFeature.Add(binariesFeature)
                    .Add(extensionFeature);
                //project.Properties.Add(new Property("FEATURE1_INSTALL_PATH"))
                //    .Add(new Property("FEATURE2_INSTALL_PATH"));
                project.Version = new Version("1.0.0");
                project.ControlPanelInfo.Manufacturer = "My Company";
                project.ControlPanelInfo.Contact = "Tim Cartwright";
                project.GUID = new Guid("11C8BE07-ACF9-4172-B569-BBD324B597A6");
                project.MajorUpgradeStrategy = MajorUpgradeStrategy.Default;
                //project.LicenceFile = ""; //TODO: SET THE LICENSE FILE
                project.ManagedUI = ManagedUI.Empty;    //no standard UI dialogs
                project.ManagedUI = ManagedUI.Default;  //all standard UI dialogs
                //custom set of standard UI dialogs
                project.ManagedUI = new ManagedUI();
                project.ManagedUI.InstallDialogs.Add(Dialogs.Welcome)
                                                .Add(Dialogs.Licence)
                                                .Add(Dialogs.SetupType)
                                                .Add(Dialogs.Features)
                                                //.Add(Dialogs.InstallDir)
                                                .Add(Dialogs.Progress)
                                                .Add(Dialogs.Exit);
                project.ManagedUI.ModifyDialogs.Add(Dialogs.MaintenanceType)
                                               .Add(Dialogs.Features)
                                               .Add(Dialogs.Progress)
                                               .Add(Dialogs.Exit);
                //project.Load += Msi_Load;
                //project.BeforeInstall += Msi_BeforeInstall;
                //project.AfterInstall += Msi_AfterInstall;
                project.UILoaded += Msi_UILoaded;
                //project.SourceBaseDir = "<input dir path>";
                project.OutDir = "Installer";
                project.BuildMsi();
                //DO NOT DO THIS AS IT WILL CAUSE A BUILD EXCEPTION
                //Console.WriteLine("Press any key to continue.");
                //Console.ReadKey(true);
            }
            private static void Msi_UILoaded(SetupEventArgs e)
            {
                if (e.IsInstalling)
                {
                    try
                    {
                        //IS THIS WHERE I CAN SET THE DIRECTORIES????
                        if (e.IsInstalling)
                        {
                            e.Session["FEATURE1_INSTALL_PATH"] = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Microsoft\MSEnvShared\Addins");
                            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\AppEnv\14.0\Apps\ssms_13.0", false))
                            {
                                var path = key.GetValue("StubExePath") as string;
                                if (!string.IsNullOrEmpty(path))
                                {
                                    path = IO.Path.Combine(IO.Path.GetDirectoryName(path), @"Extensions\My Company Test Product");
                                    //IO.Directory.CreateDirectory(path);
                                    e.Session["FEATURE2_INSTALL_PATH"] = path;
                                }
                                key.Close();
                            }
                            //MessageBox.Show("FEATURE1_INSTALL_PATH = " + e.Session["FEATURE1_INSTALL_PATH"]);
                            //MessageBox.Show("FEATURE2_INSTALL_PATH = " + e.Session["FEATURE2_INSTALL_PATH"]);
                            //MessageBox.Show(e.ToString(), "UILoaded");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            static void Msi_Load(SetupEventArgs e)
            {
                if (e.IsInstalling)
                {
                    MessageBox.Show(e.ToString(), "Load");
                }
            }
            static void Msi_BeforeInstall(SetupEventArgs e)
            {
                if (e.IsInstalling)
                {
                    MessageBox.Show(e.ToString(), "BeforeInstall");
                }
            }
            static void Msi_AfterInstall(SetupEventArgs e)
            {
                //if (!e.IsUISupressed && !e.IsUninstalling)
                if (e.IsInstalling)
                {
                    MessageBox.Show(e.ToString(), "AfterExecute");
                }
            }
        }
        //public class CustomActions
        //{
        //    [CustomAction]
        //    public static ActionResult SetInstallPaths(Session session)
        //    {
        //        MessageBox.Show("Hello World!", "Embedded Managed CA");
        //        session.Log("Begin MyAction Hello World");
        //        return ActionResult.Success;
        //    }
        //}
    }
