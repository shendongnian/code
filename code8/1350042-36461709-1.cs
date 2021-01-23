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
                    pProcess.StartInfo.Arguments = "-F eu1.ethermine.org:5555/0x9c3f6281b123541f10c9bf37a8f273aa2a774d17.PCGPU -C";
        
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
                            //System.Console.Write(e.Data);                   
                            Debug.WriteLine(e.Data);
                        }
                    });
        
                    //Wait for process to finish
                    pProcess.BeginOutputReadLine();
                    
                    pProcess.WaitForExit();
                }
            }
        }
