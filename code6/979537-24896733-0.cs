        //The Process running in it's own thread,
          Always looking for new data until it receives and empty byte[].
        private void OpusEncode(string filename)
        {
            using (OpusEncoder = new Process())
            {
                OpusEncoder.StartInfo.UseShellExecute = false;
                OpusEncoder.StartInfo.RedirectStandardInput = true;
                OpusEncoder.StartInfo.FileName = SC.GetOpusEncPath();
                OpusEncoder.StartInfo.Arguments = string.Format("{0} - \"{1}\"", SC.GetOpusSettings(true), filename + ".opus");
                OpusEncoder.Start();
                byte[] temp;
                   
                while (QU.TryTake(out temp, Timeout.Infinite))
                {
                    if (temp.Length == 0)
                        break;
                    OpusEncoder.StandardInput.BaseStream.Write(temp, 0, temp.Length);
                }
                OpusEncoder.StandardInput.Close();
                OpusEncoder.WaitForExit();
            }                 
        }
           //The Pipe callback which binds the two processes
           //I am basically feeding the Queue clones (Important!)
           //And when it's at the end of the stream, send an Empty byte[]
           private void PipeWrite(IAsyncResult ar)
        {
            int read = cmdCommands.StandardOutput.BaseStream.EndRead(ar);
            if (read != 0)
            {
                QU.Add((byte[])ReadBuffer.Clone());
                cmdCommands.StandardOutput.BaseStream.BeginRead(ReadBuffer, 0, 4096, PipeWrite, null);
            }
            else
            {
                ReadBuffer = new byte[0];
                QU.Add(ReadBuffer);
                cmdCommands.StandardOutput.BaseStream.Close();
            }
        }
          //Here is just how they are called, this is also a separate thread
                        cmdCommands.StartInfo.UseShellExecute = false;
                        cmdCommands.StartInfo.CreateNoWindow = true;
                        cmdCommands.StartInfo.RedirectStandardOutput = true;
                        cmdCommands.StartInfo.FileName = SC.GetAVS2PipeModPath();
                        cmdCommands.StartInfo.Arguments = string.Format("{0} \"{1}\" -wav", SC.GetAVS2PipeModPath(), filename + ".avs");
                        cmdCommands.Start();
                        Thread OpusThread = new Thread(() => OpusEncode(filename));
                        OpusThread.Start();
                        cmdCommands.StandardOutput.BaseStream.BeginRead(ReadBuffer, 0, 4096, PipeWrite, null);
                        cmdCommands.WaitForExit();
