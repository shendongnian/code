           using(var fs = new FileStream(fileLoc, FileMode.Open, FileAccess.Read, FileShare.Read)) {
            var bin = new byte[(int)fs.Length];
			// u can use usual  stream pattern 
			int l = 0; while((l= fs.Read(bin,l,bin.Length-l))<bin.Length);
            foreach (var b in bin)
            {
                Console.Write((char)b);
            }
           }
