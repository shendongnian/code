      if(File.Exist(patch.SAF_Path))
    {
    BinaryReader br = new BinaryReader(File.OpenRead(patch.SAF_Path));
                br.BaseStream.Position = (long)f.Start;
                byte[] file = br.ReadBytes((int)f.Length);
                br.Dispose();
                BinaryWriter bw = new BinaryWriter(File.OpenWrite(SAF_Path));
                bw.BaseStream.Position = (int)new FileInfo(SAF_Path).Length;
                f.Start = (ulong)bw.BaseStream.Position;
                bw.Write(file);
                bw.Dispose();
                current_folder.Files.Add(f);
                f.Start = BitConverter.ToUInt64(file, Offset);
                Offset += 8;
                f.Length = BitConverter.ToUInt64(file, Offset);
                Offset += 8;
    }
    else
    {
    //do somethings else downloand this file maybe and try read it
    }
