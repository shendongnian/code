    using System;
    using System.IO;
    using System.IO.Pipes;
    using System.IO.Ports;
    using System.Diagnostics;
    using System.Threading;
    
    class PipeListener
    {
    
        static void Main(string[] args)
        {
            Console.WriteLine("\n***Named piper server example ***\n");
            NamedPipeServerStream pipe = new NamedPipeServerStream("/tmp/test");
            pipe.WaitForConnection();
            StreamReader reader = new StreamReader(pipe);
            int i = 0;
            String tty = "";
            String cmd = "";
            while(i < 10)
            {
                Console.WriteLine("Waiting for pipe.");
                var line = reader.ReadLine();
                tty = Command.getTTY(line);
                cmd = Command.getCommand(line);
    
                echoCommand(tty, cmd);
                Console.WriteLine("Recevied command: " +line);
                i++;
            }
            pipe.Close();
        }
    
        public static void echoCommand(String tty, String command)
        {
            if (tty != "" && File.Exists(tty))
            {
                String output = String.Format("\nYour command was: {0}\n", command);
                byte[] bytes = new byte[output.Length * sizeof(char)];
                System.Buffer.BlockCopy(output.ToCharArray(), 0, bytes, 0,
                                        bytes.Length);
    
                FileStream term = new FileStream(tty, FileMode.Open,
                        FileAccess.Write, FileShare.Write);
    
                term.Write(bytes, 0, bytes.Length);
                term.Flush(true);
                term.Dispose();
            }
        }
    }
    
    class Command
    {
        public static String getTTY(String str)
        {
            String[] words = str.Split(' ');
            return words[0];
        }
    
        public static String getCommand(String str)
        {
            String[] words = str.Split(' ');
            String[] cmd = new String[words.Length-1];
            Array.Copy(words,1,cmd,0, words.Length - 1);
            return String.Join(" ", cmd);
        }
    }
