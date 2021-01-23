                        for (int i = 0; i < resources.Count; i++)
                        {
                            Console.WriteLine("Extracting file: " + resources[i] + "...");
                            Stream stream = thisExe.GetManifestResourceStream(resources[i]);
                            byte[] bytes = new byte[(int)stream.Length];
                            stream.Read(bytes, 0, bytes.Length);
                            File.WriteAllBytes(dir + resources[i], bytes);
                        }
