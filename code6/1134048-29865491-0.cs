          private static void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                while (!string.IsNullOrEmpty(e.Data))
                {
                    Console.Write("OutputDataReceived: " + e.Data + Environment.NewLine);
                }
            }
    ​
