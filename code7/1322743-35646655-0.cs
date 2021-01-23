            Process p = StartElevatedProcess(
                "script.bat",
                true);
            do
            {
                char[] buff = new char[1000];
                int i = p.StandardOutput.Read(buff, 0, buff.Length);
                string output = new String(buff, 0, i);
                if (output.Contains("Please enter value for FOO:"))
                {
                    Console.WriteLine(output);
                    p.StandardInput.WriteLine("Foo value");
                }
                else if (output.Contains("Please enter value for BAR:"))
                {
                    Console.WriteLine(output);
                    p.StandardInput.WriteLine("Bar value");
                }
                else if (output.Contains(". . ."))
                {
                    // Handle "Hit any key to continue"
                    p.StandardInput.WriteLine();
                }
                else
                {
                    Console.WriteLine(output);
                }
                Thread.Sleep(100);
            } while (!p.HasExited);
