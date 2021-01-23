            if (m.Msg == NativeMethods.SendArg)
            {
                string s;
                using (var mmf = MemoryMappedFile.OpenExisting("testmap"))
                {
                    using (var stm = mmf.CreateViewStream())
                    {
                        s = new BinaryReader(stm).ReadString();
                    }
                }
                listBox1.Items.Add(s);
            }
