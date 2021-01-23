    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    using System.IO;
    using System.Threading;
    using IronPython.Hosting;
    using Microsoft.Scripting;
    using Microsoft.Scripting.Hosting;
    
    namespace AsyncIronPython
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            string script;
            ScriptEngine engine;
            ScriptScope scope;
            Thread threadScript;
    
            public MainWindow()
            {
                InitializeComponent();
    
                engine = Python.CreateEngine();
                scope = engine.CreateScope();
                string variableName = "isto";
                object gridMier = gridScript;
                scope.SetVariable(variableName, gridMier);
                scope.SetVariable("execute_in_ui", new Action<object>(ExecuteInUI));
            }
    
            public void ExecuteInUI(object obj)
            {
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    var op = engine.CreateOperations(scope);
                    op.Invoke(obj);
                }));
            }
    
            public void rodarScript()
            {
                try
                {
                    //PARTE PARA ADICIONAR BIBLIOTECAS BASICAS PARA DESENVOLVIMENTO COM OS SCRIPTS
                    script = @"#Reference the WPF assemblies
    import clr
    clr.AddReferenceByName(""PresentationFramework, Version = 3.0.0.0, Culture =       neutral, PublicKeyToken = 31bf3856ad364e35"")
    clr.AddReferenceByName(""PresentationCore, Version=3.0.0.0, Culture=neutral,     PublicKeyToken=31bf3856ad364e35"")
    import System.Windows
    def getMyObject():
        return isto
    
    objeto = getMyObject()
    
    #Atalhos de referencias para adicionar
    Thickness = System.Windows.Thickness
    from System.Threading.Thread import Sleep
    Debug = System.Diagnostics.Debug";
    
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        script = script + "\n" + textBoxScript.Text;
                    }));
    
                    var source = engine.CreateScriptSourceFromString(script, SourceCodeKind.Statements);
                    //var compiled = source.Compile();
                    //var result = compiled.Execute(scope);
                    source.Execute(scope);
                }
                catch (Exception qualquerExcecaoEncontrada)
                {
                    MessageBox.Show(qualquerExcecaoEncontrada.ToString(), "Scripting Test do Mier", MessageBoxButton.OK);
                }
            }
    
            private void buttonScript_Click(object sender, RoutedEventArgs e)
            {
                threadScript = new Thread(rodarScript);
                threadScript.Start();
            }
        }
    }
