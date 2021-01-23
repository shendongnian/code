        /// <summary>
        /// A string used to write into the bash and allows us to detect when the bash finished to write it's output.
        /// </summary>
        const string delimiterString = "#WAITING";
        /// <summary>
        /// Runs the specified command and return it's output.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public string RunCommand(string command)
        {
            sessionProcess.StandardInput.WriteLine(command);
            // Add a special string to be recognized when output is waiting
            sessionProcess.StandardInput.WriteLine("echo \"" + delimiterString + "\"");
            string output = "";
            int lastChr = 0;
            do
            {
                lastChr = sessionProcess.StandardOutput.Read();
                string outputChr = null;
                outputChr += sessionProcess.StandardOutput.CurrentEncoding.GetString(new byte[] { (byte)lastChr });
                output += outputChr;
                if (output.EndsWith(delimiterString))
                {
                    // Remove delimeter
                    output = output.Replace(Environment.NewLine + delimiterString, "");
                    output = output.Replace(delimiterString + Environment.NewLine, "");
                    // Console.Write(output);
                    break;
                }
            } while (lastChr > 0);
            return output;
        }
 
