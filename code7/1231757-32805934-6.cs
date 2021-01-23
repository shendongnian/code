    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Threading;
    using System.IO;
    
    namespace Windamow
    {
        public static class WebBrowserUtility
        {
            public static readonly DependencyProperty BindableSourceProperty =
                                   DependencyProperty.RegisterAttached("BindableSource", typeof(string),
                                   typeof(WebBrowserUtility), new UIPropertyMetadata(null,
                                   BindableSourcePropertyChanged));
    
            public static string GetBindableSource(DependencyObject obj)
            {
                return (string)obj.GetValue(BindableSourceProperty);
            }
    
            public static void SetBindableSource(DependencyObject obj, string value)
            {
                obj.SetValue(BindableSourceProperty, value);
            }
    
            public static void BindableSourcePropertyChanged(DependencyObject o,
                                                             DependencyPropertyChangedEventArgs e)
            {
                WebBrowser webBrowser = (WebBrowser)o;
                webBrowser.NavigateToString((string)e.NewValue);
            }
        }
    
    
        public class Windamow
        {
            public static DynamoWindow window;
    
            public static string html;
    
            internal void ThreadProc()
            {
                string appName = "";
                try
                {
                    appName = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
    
                    const string IE_EMULATION = @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
    
                    using (var fbeKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(IE_EMULATION, true))
                    {
    
                        fbeKey.SetValue(appName, 9000, Microsoft.Win32.RegistryValueKind.DWord);
    
                    }
                }
    
                catch (Exception ex)
                {
                    MessageBox.Show(appName + "\n" + ex.ToString(), "Unexpected error setting browser mode!");
                }
    
                window = new DynamoWindow();
                window.ShowDialog();
            }
    
            internal Windamow()
            {
                Thread t = new Thread(ThreadProc);
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
    
            /// <summary>
            /// asd
            /// </summary>
            /// <param name="launch"></param>
            /// <param name="_html"></param>
            /// <returns></returns>
            public static void MakeWindow(bool launch, string _html)
            {
                Windamow mow = new Windamow();
                //return mow.window;
    
                //if (launch)
                //{
                //    if (MyProject.Utility.WebBrowserUtility.IsWindowOpen<Window>("MainWindow"))
                //    {
                //        html = _html;
                //        return null;
                //    }
                //    else
                //    {
                //        html = _html;
                //        Windamow mow = new Windamow();
                //        return mow.window;
                //    }
                //}
                //else
                //{
                //    return null;
                //}
            }
        }
    }
