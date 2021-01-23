        [Test]
        public void UpdateEncoding()
        {
            string path = @"C:\dev\Cash\src";
            foreach (var file in Directory.GetFiles(path, "*.cs", SearchOption.AllDirectories))
            {
                if (HasBom(file))
                    continue;
                Console.WriteLine(file);
                var content = File.ReadAllText(file, Encoding.GetEncoding("windows-1251"));
                File.WriteAllText(file, content, Encoding.UTF8);
            }
        }
        private bool HasBom(string file)
        {
            using (var strm = new FileStream(file, FileMode.Open))
            {
                foreach (var b in Encoding.UTF8.GetPreamble())
                {
                    if (strm.ReadByte() != b)
                        return false;
                }
                return true;
            }
        }
