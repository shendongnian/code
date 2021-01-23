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
    using System.Diagnostics;
    
    namespace ETHMinerVisualiser
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void MineButton_Click(object sender, RoutedEventArgs e)
            {
                Task.Run(() => { startMining(); });
            }
    
            public void startMining()
            {
                //Create process
                System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
    
                //strCommand is path and file name of command to run
                pProcess.StartInfo.FileName = @"E:/Documents/ETH/ETHMinerVisualiser/ethminer-cuda-0.9.41-new/ethminer.exe";
    
                //strCommandParameters are parameters to pass to program
                pProcess.StartInfo.Arguments = " --farm-recheck 200 -F http://127.0.0.1:8080/PCGPU --cl-extragpu-mem 256 --cuda-turbo";
    
                pProcess.StartInfo.UseShellExecute = false;
                
    
                //Set output of program to be written to process output stream
                pProcess.StartInfo.RedirectStandardOutput = true;
    
                //Optional
                pProcess.StartInfo.WorkingDirectory = "";
    
                //Start the process
                pProcess.Start();
    
                //pProcess.StartInfo.CreateNoWindow = true;
    
                //pProcess.BeginOutputReadLine();
    
                pProcess.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
                {
                    // Prepend line numbers to each line of the output.
                    if (!String.IsNullOrEmpty(e.Data))
                    {
                        System.Console.Write(e.Data);
                        //textBox.Text = e.Data;
                    }
                });
    
                //Wait for process to finish
                pProcess.BeginOutputReadLine();
    
                pProcess.WaitForExit();
            }
        }
    }
