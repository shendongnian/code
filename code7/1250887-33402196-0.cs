            int counter = 0;
            string proposedDest = dest;
            while(counter < 5000)
            {
                if (!File.Exists(proposedDest))
                {
                    try
                    {
                        File.Copy(fileToCopy, proposedDest);
                        break;
                    }
                    catch (IOException ex) when ((uint)ex.HResult == 0x80070050)
                    {
                    }
                }
                counter++;
                proposedDest = Path.Combine(Path.GetDirectoryName(dest),
                    Path.GetFileNameWithoutExtension(dest) + "_" + counter + Path.GetExtension(dest));
            }
            ;
            if (counter == 5000) throw new Exception("Could not copy file " + fileToCopy + " too many retries");
